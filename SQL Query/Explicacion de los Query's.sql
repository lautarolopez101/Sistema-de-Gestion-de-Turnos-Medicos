/* ============================================================
   0) CONTEXTO
   Este script asume que ya existen:
   - dbo.Usuarios (ID_Usuario, Username, PasswordHash, ...)
   - dbo.Familias (ID_Familia, Nombre, ...)
   - dbo.Patentes (ID_Patente, Nombre, ...)
   ============================================================ */

----------------------------------------------------------------
-- 1) TABLAS PUENTE (si no existen)
----------------------------------------------------------------
-- IF OBJECT_ID(...) IS NULL   →   sólo crea si no existe
IF OBJECT_ID('dbo.Familia_Patente') IS NULL
BEGIN
    /* CREATE TABLE  →  crea una tabla nueva                                */
    /* dbo.Familia_Patente → nombre esquema.tabla                           */
    CREATE TABLE dbo.Familia_Patente
    (
        /* INT NOT NULL → columna entera obligatoria                        */
        ID_Familia   INT NOT NULL,
        ID_Patente   INT NOT NULL,

        /* DATETIME2 → fecha/hora con más precisión                          */
        /* DEFAULT SYSUTCDATETIME() → si no envías valor, usa fecha/hora UTC */
        CreatedAtUtc DATETIME2 NOT NULL CONSTRAINT DF_FP_CreatedAt DEFAULT SYSUTCDATETIME(),
        CreatedBy    NVARCHAR(100) NULL,

        /* PRIMARY KEY (ID_Familia, ID_Patente) → clave compuesta (evita duplicados) */
        CONSTRAINT PK_Familia_Patente PRIMARY KEY (ID_Familia, ID_Patente),

        /* FOREIGN KEY ... REFERENCES ... → define relación con tabla padre         */
        /* ON DELETE CASCADE → si se borra la familia/patente, borra el vínculo     */
        CONSTRAINT FK_FP_Familia FOREIGN KEY (ID_Familia)
            REFERENCES dbo.Familias(ID_Familia) ON DELETE CASCADE,
        CONSTRAINT FK_FP_Patente FOREIGN KEY (ID_Patente)
            REFERENCES dbo.Patentes(ID_Patente) ON DELETE CASCADE
    );
END
GO

IF OBJECT_ID('dbo.Usuario_Familia') IS NULL
BEGIN
    CREATE TABLE dbo.Usuario_Familia
    (
        ID_Usuario   INT NOT NULL,
        ID_Familia   INT NOT NULL,
        CreatedAtUtc DATETIME2 NOT NULL CONSTRAINT DF_UF_CreatedAt DEFAULT SYSUTCDATETIME(),
        CreatedBy    NVARCHAR(100) NULL,
        CONSTRAINT PK_Usuario_Familia PRIMARY KEY (ID_Usuario, ID_Familia),
        CONSTRAINT FK_UF_Usuario FOREIGN KEY (ID_Usuario)
            REFERENCES dbo.Usuarios(ID_Usuario) ON DELETE CASCADE,
        CONSTRAINT FK_UF_Familia FOREIGN KEY (ID_Familia)
            REFERENCES dbo.Familias(ID_Familia) ON DELETE CASCADE
    );
END
GO

IF OBJECT_ID('dbo.Usuario_Patente') IS NULL
BEGIN
    CREATE TABLE dbo.Usuario_Patente
    (
        ID_Usuario   INT NOT NULL,
        ID_Patente   INT NOT NULL,
        CreatedAtUtc DATETIME2 NOT NULL CONSTRAINT DF_UP_CreatedAt DEFAULT SYSUTCDATETIME(),
        CreatedBy    NVARCHAR(100) NULL,
        CONSTRAINT PK_Usuario_Patente PRIMARY KEY (ID_Usuario, ID_Patente),
        CONSTRAINT FK_UP_Usuario FOREIGN KEY (ID_Usuario)
            REFERENCES dbo.Usuarios(ID_Usuario) ON DELETE CASCADE,
        CONSTRAINT FK_UP_Patente FOREIGN KEY (ID_Patente)
            REFERENCES dbo.Patentes(ID_Patente) ON DELETE CASCADE
    );
END
GO

----------------------------------------------------------------
-- 2) ÍNDICES ÚNICOS/DE APOYO (mejoran integridad y performance)
----------------------------------------------------------------
-- CREATE UNIQUE INDEX → no permite duplicados en esa columna
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_Familias_Nombre' AND object_id = OBJECT_ID('dbo.Familias'))
    CREATE UNIQUE INDEX UX_Familias_Nombre ON dbo.Familias(Nombre);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_Patentes_Nombre' AND object_id = OBJECT_ID('dbo.Patentes'))
    CREATE UNIQUE INDEX UX_Patentes_Nombre ON dbo.Patentes(Nombre);

-- Índices simples en FKs (aceleran joins)
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_FP_Familia' AND object_id = OBJECT_ID('dbo.Familia_Patente'))
    CREATE INDEX IX_FP_Familia ON dbo.Familia_Patente(ID_Familia);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_FP_Patente' AND object_id = OBJECT_ID('dbo.Familia_Patente'))
    CREATE INDEX IX_FP_Patente ON dbo.Familia_Patente(ID_Patente);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_UF_Usuario' AND object_id = OBJECT_ID('dbo.Usuario_Familia'))
    CREATE INDEX IX_UF_Usuario ON dbo.Usuario_Familia(ID_Usuario);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_UF_Familia' AND object_id = OBJECT_ID('dbo.Usuario_Familia'))
    CREATE INDEX IX_UF_Familia ON dbo.Usuario_Familia(ID_Familia);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_UP_Usuario' AND object_id = OBJECT_ID('dbo.Usuario_Patente'))
    CREATE INDEX IX_UP_Usuario ON dbo.Usuario_Patente(ID_Usuario);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_UP_Patente' AND object_id = OBJECT_ID('dbo.Usuario_Patente'))
    CREATE INDEX IX_UP_Patente ON dbo.Usuario_Patente(ID_Patente);
GO

----------------------------------------------------------------
-- 3) VINCULAR FAMILIAS ↔ PATENTES
----------------------------------------------------------------
/* BEGIN TRAN / COMMIT → abre/cierra transacción:
   Si algo falla, se deshace todo, así la BD no queda a medias.         */
SET XACT_ABORT ON;
BEGIN TRAN;

-- A) ADMINISTRADOR → TODAS LAS PATENTES
/* INSERT INTO ... SELECT ...  → inserta filas resultado de un SELECT   */
/* CROSS JOIN → combina 1 fila de Familia Admin con todas las Patentes  */
/* WHERE ... NOT EXISTS (...) → evita duplicar vínculos ya existentes   */
INSERT INTO dbo.Familia_Patente (ID_Familia, ID_Patente, CreatedBy)
SELECT f.ID_Familia, p.ID_Patente, 'seed'
FROM dbo.Familias f
CROSS JOIN dbo.Patentes p
WHERE f.Nombre = 'Administrador'
  AND NOT EXISTS (
        SELECT 1
        FROM dbo.Familia_Patente fp
        WHERE fp.ID_Familia = f.ID_Familia
          AND fp.ID_Patente = p.ID_Patente
      );

-- B) PROFESIONAL → set recomendado
/* WITH ... AS (...)  → CTE (consulta nombrada temporal)                */
WITH Pats AS (
  SELECT Nombre FROM (VALUES
    ('Paciente.Ver'),
    ('Turno.Asignar'),
    ('Turno.Editar'),
    ('Turno.Cancelar'),
    ('Turno.Ver'),
    ('Turno.VerAgendaPropia')
  ) v(Nombre)
)
INSERT INTO dbo.Familia_Patente (ID_Familia, ID_Patente, CreatedBy)
SELECT f.ID_Familia, p.ID_Patente, 'seed'
FROM dbo.Familias f
JOIN Pats  ON 1=1                   -- truco: une todas las filas de Pats
JOIN dbo.Patentes p ON p.Nombre = Pats.Nombre
WHERE f.Nombre = 'Profesional'
  AND NOT EXISTS (
        SELECT 1 FROM dbo.Familia_Patente x
        WHERE x.ID_Familia = f.ID_Familia AND x.ID_Patente = p.ID_Patente
      );

-- C) RECEPCION
WITH Pats AS (
  SELECT Nombre FROM (VALUES
    ('Paciente.Crear'),
    ('Paciente.Editar'),
    ('Paciente.Eliminar'),
    ('Paciente.Ver'),
    ('Turno.Asignar'),
    ('Turno.Editar'),
    ('Turno.Cancelar'),
    ('Turno.Ver')
  ) v(Nombre)
)
INSERT INTO dbo.Familia_Patente (ID_Familia, ID_Patente, CreatedBy)
SELECT f.ID_Familia, p.ID_Patente, 'seed'
FROM dbo.Familias f
JOIN Pats ON 1=1
JOIN dbo.Patentes p ON p.Nombre = Pats.Nombre
WHERE f.Nombre = 'Recepcion'
  AND NOT EXISTS (
        SELECT 1 FROM dbo.Familia_Patente x
        WHERE x.ID_Familia = f.ID_Familia AND x.ID_Patente = p.ID_Patente
      );

-- D) PACIENTE
WITH Pats AS (
  SELECT Nombre FROM (VALUES
    ('Paciente.VerPropios'),
    ('Turno.VerPropios')
  ) v(Nombre)
)
INSERT INTO dbo.Familia_Patente (ID_Familia, ID_Patente, CreatedBy)
SELECT f.ID_Familia, p.ID_Patente, 'seed'
FROM dbo.Familias f
JOIN Pats ON 1=1
JOIN dbo.Patentes p ON p.Nombre = Pats.Nombre
WHERE f.Nombre = 'Paciente'
  AND NOT EXISTS (
        SELECT 1 FROM dbo.Familia_Patente x
        WHERE x.ID_Familia = f.ID_Familia AND x.ID_Patente = p.ID_Patente
      );

COMMIT;
GO

----------------------------------------------------------------
-- 4) ASIGNAR ROLES A USUARIOS (Usuario ↔ Familia)
----------------------------------------------------------------
/* Ejemplo: darle "Administrador" a un usuario por Username              */
/* JOIN ... ON ...  → une tablas por condición                           */
INSERT INTO dbo.Usuario_Familia (ID_Usuario, ID_Familia, CreatedBy)
SELECT u.ID_Usuario, f.ID_Familia, 'seed'
FROM dbo.Usuarios  u
JOIN dbo.Familias f ON f.Nombre = 'Administrador'
WHERE u.Username = 'tu_usuario_admin'
  AND NOT EXISTS (
        SELECT 1 FROM dbo.Usuario_Familia uf
        WHERE uf.ID_Usuario = u.ID_Usuario AND uf.ID_Familia = f.ID_Familia
      );

-- Otro ejemplo: asignar "Recepcion" a la usuaria 'recepcion.1'
INSERT INTO dbo.Usuario_Familia (ID_Usuario, ID_Familia, CreatedBy)
SELECT u.ID_Usuario, f.ID_Familia, 'seed'
FROM dbo.Usuarios  u
JOIN dbo.Familias f ON f.Nombre = 'Recepcion'
WHERE u.Username = 'recepcion.1'
  AND NOT EXISTS (
        SELECT 1 FROM dbo.Usuario_Familia uf
        WHERE uf.ID_Usuario = u.ID_Usuario AND uf.ID_Familia = f.ID_Familia
      );
GO

----------------------------------------------------------------
-- 5) CONSULTAS DE VERIFICACIÓN (solo lectura)
----------------------------------------------------------------
-- Patentes por familia (te muestra qué quedó asignado)
SELECT f.Nombre AS Familia, p.Nombre AS Patente
FROM dbo.Familia_Patente fp
JOIN dbo.Familias f ON f.ID_Familia = fp.ID_Familia
JOIN dbo.Patentes p ON p.ID_Patente = fp.ID_Patente
ORDER BY f.Nombre, p.Nombre;

-- Familias por usuario (qué rol tiene cada usuario)
SELECT u.Username, f.Nombre AS Familia
FROM dbo.Usuario_Familia uf
JOIN dbo.Usuarios u ON u.ID_Usuario = uf.ID_Usuario
JOIN dbo.Familias f ON f.ID_Familia = uf.ID_Familia
ORDER BY u.Username, f.Nombre;
