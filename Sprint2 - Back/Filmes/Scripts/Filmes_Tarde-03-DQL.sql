USE Filmes_tarde;

SELECT * FROM Generos;
SELECT * FROM Filmes;
SELECT * FROM Usuarios

SELECT IdGenero, Nome from Generos;

SELECT IdUsuario, Email, Senha, Permissao FROM Usuarios WHERE Email = 'saulo@email.com' AND Senha = '123';