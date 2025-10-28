INSERT INTO Profesionales_Especialidades (ID_Especialidad, ID_Profesional, CreatedAtUtc)
VALUES
-- Prof 1 (ya tenía 1)  -> agrego 2,3
(2, 1, GETUTCDATE()), (3, 1, GETUTCDATE()),
-- Prof 2 (ya tenía 3)  -> agrego 1,5
(1, 2, GETUTCDATE()), (5, 2, GETUTCDATE()),
-- Prof 3 (ya tenía 4)  -> agrego 2,6
(2, 3, GETUTCDATE()), (6, 3, GETUTCDATE()),
-- Prof 4 (ya tenía 2)  -> agrego 1,4
(1, 4, GETUTCDATE()), (4, 4, GETUTCDATE()),
-- Prof 5 (ya tenía 5)  -> agrego 2,8
(2, 5, GETUTCDATE()), (8, 5, GETUTCDATE()),
-- Prof 6 (ya tenía 6)  -> agrego 4,7
(4, 6, GETUTCDATE()), (7, 6, GETUTCDATE()),
-- Prof 7 (ya tenía 7)  -> agrego 3,6
(3, 7, GETUTCDATE()), (6, 7, GETUTCDATE()),
-- Prof 8 (ya tenía 8)  -> agrego 4,10
(4, 8, GETUTCDATE()), (10, 8, GETUTCDATE()),
-- Prof 9 (ya tenía 1)  -> agrego 2,9
(2, 9, GETUTCDATE()), (9, 9, GETUTCDATE()),
-- Prof 10 (ya tenía 5) -> agrego 1,6
(1, 10, GETUTCDATE()), (6, 10, GETUTCDATE()),
-- Prof 11 (ya tenía 4) -> agrego 2,7
(2, 11, GETUTCDATE()), (7, 11, GETUTCDATE()),
-- Prof 12 (ya tenía 2) -> agrego 3,5
(3, 12, GETUTCDATE()), (5, 12, GETUTCDATE()),
-- Prof 13 (ya tenía 9) -> agrego 1,8
(1, 13, GETUTCDATE()), (8, 13, GETUTCDATE()),
-- Prof 14 (ya tenía 10)-> agrego 3,9
(3, 14, GETUTCDATE()), (9, 14, GETUTCDATE()),
-- Prof 15 (ya tenía 6) -> agrego 5,10
(5, 15, GETUTCDATE()), (10, 15, GETUTCDATE()),
-- Prof 16 (ya tenía 7) -> agrego 2,8
(2, 16, GETUTCDATE()), (8, 16, GETUTCDATE()),
-- Prof 17 (ya tenía 8) -> agrego 4,9
(4, 17, GETUTCDATE()), (9, 17, GETUTCDATE()),
-- Prof 18 (ya tenía 9) -> agrego 5,10
(5, 18, GETUTCDATE()), (10, 18, GETUTCDATE()),
-- Prof 19 (ya tenía 10)-> agrego 6,1
(6, 19, GETUTCDATE()), (1, 19, GETUTCDATE()),
-- Prof 20 (ya tenía 3) -> agrego 2,4
(2, 20, GETUTCDATE()), (4, 20, GETUTCDATE());
