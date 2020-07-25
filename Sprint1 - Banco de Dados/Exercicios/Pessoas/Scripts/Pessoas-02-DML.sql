USE Pessoas_Tarde;

INSERT INTO Pessoas (Nome)
VALUES ('Larissa'), ('Mayara'), ('Fabiane'), ('Leonardo'), ('Kauê');

INSERT INTO Emails (Descricao, IdPessoa)
VALUES	('lari.c@gmail.com', 1),
		('may.l@gmail.com', 2),
		('fabi.s@gmail.com', 3),
		('leo.o@gmail.com', 4),
		('kau.e@gmail.com', 5);

INSERT INTO Telefones (Descricao, IdPessoa)
VALUES	('941982260', 1),
		('937843376', 2),
		('940043568', 3),
		('975403823', 4),
		('948165334', 5);

INSERT INTO CNH (Descricao, IdPessoa)
VALUES	('94198226012', 1),
		('93784337613', 2),
		('94004356814', 3),
		('97540382315', 4),
		('94816533416', 5);

INSERT INTO Emails (Descricao, IdPessoa)
VALUES ('laris.laris@gmail.com', 1);

INSERT INTO Telefones (Descricao, IdPessoa)
VALUES ('94816533417', 2);

DELETE Emails FROM Pessoas WHERE IdEmail = 4;
DELETE Telefones FROM Pessoas WHERE IdTelefone = 4;
DELETE CNH FROM Pessoas WHERE IdCNH = 4;

SELECT * FROM Pessoas;
SELECT * FROM Emails;
SELECT * FROM Telefones;
SELECT * FROM CNH;
