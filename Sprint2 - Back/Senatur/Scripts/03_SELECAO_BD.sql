USE Senatur_Tarde;

SELECT * FROM Pacotes;
SELECT * FROM TiposUsuario;
SELECT * FROM Usuarios;

SELECT IdPacote, NomePacote FROM Pacotes; 
GO

SELECT U.IdUsuario, U.Email, U.IdTipoUsuario, TU.Titulo FROM Usuarios U
INNER JOIN TiposUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario;
GO

SELECT IdUsuario, Email, U.IdTipoUsuario, TU.Titulo FROM Usuarios U
INNER JOIN TiposUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
WHERE Email = 'admin@admin.com' AND Senha = 'admin';
GO