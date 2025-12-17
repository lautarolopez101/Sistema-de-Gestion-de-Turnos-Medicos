using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BackupService
    {
        private static string CarpetaAppData =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TurnosMedicos");

        private static string ArchivoUltimoBackup =>
            Path.Combine(CarpetaAppData, "last_backup.txt");

        public static bool AsegurarBackupDiario(string databaseName, string carpetaBackups)
        {
            // Devuelve true si HIZO backup, false si NO hacía falta

            Directory.CreateDirectory(CarpetaAppData);
            Directory.CreateDirectory(carpetaBackups);

            DateTime hoy = DateTime.UtcNow.Date;

            // 1) leer última fecha
            if (File.Exists(ArchivoUltimoBackup))
            {
                string txt = File.ReadAllText(ArchivoUltimoBackup).Trim();
                if (DateTime.TryParseExact(txt, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var ultima))
                {
                    if (ultima.Date == hoy)
                        return false; // hoy ya se hizo
                }
            }

            // 2) armar nombre de archivo .bak con fecha/hora
            string nombre = $"{databaseName}_{DateTime.UtcNow:yyyy-MM-dd_HH-mm-ss}.bak";
            string fullPath = Path.Combine(carpetaBackups, nombre);

            // 3) hacer backup
            BackupDAL.CrearBackup(databaseName, fullPath);

            // 4) guardar que ya se hizo hoy
            File.WriteAllText(ArchivoUltimoBackup, hoy.ToString("yyyy-MM-dd"));

            return true;
        }
    }
}
