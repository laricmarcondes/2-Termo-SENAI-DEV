USE InLock_Games_Tarde;

INSERT INTO Estudios(NomeEstudio)
VALUES	('Blizzard'),
		('Rockstar Studios'),
		('Square Enix');

INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,Valor,IdEstudio)
VALUES	('Diablo 3','� um jogo que cont�m bastante a��o e � viciante,seja voc� um novato ou um f�','15/05/2012', 99.00,1);

INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,Valor,IdEstudio)
VALUES	('Red Dead Redemption II','jogo eletr�nico de a��o-aventura westen','26/09/2018',120.00, 2);

INSERT INTO TiposUsuario(Tipo)
VALUES	('Administrador'),('Cliente');

INSERT INTO Usuarios(Email,Senha, IdTipoUsuario)
VALUES	('admin@admin.com','adm',1),('cliente@cliente.com','cliente',2);

SELECT * FROM Estudios;
SELECT * FROM Jogos;
SELECT * FROM TiposUsuario;
SELECT * FROM Usuarios;