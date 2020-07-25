USE Livros_Tarde;

INSERT INTO Autores(NomeAutor)
VALUES ('Rick Riordan'), ('Kiera Kass'), ('Stepheb King'), ('Jojo Moyes'), ('Suzanne Collins');

INSERT INTO Generos (Nome)
VALUES ('Ficção'), ('Distopia'), ('Mistério'), ('Romance'), ('Aventura');

INSERT INTO Livros (Titulo, IdAutor, IdGenero)
VALUES	('Percy Jackson', 1, 1),
		('A Coroa', 2, 2),
		('Mr.Mercedes', 3, 3),
		('A Garota Que Você Deixou Para Trás', 4, 4),
		('Jogos Vorazes', 5, 5);

UPDATE Generos
SET Nome = 'Ficção juvenil'
WHERE IdGenero = 2;

DELETE FROM Livros
WHERE IdLivro=3;

DELETE FROM Autores
WHERE IdAutor=3;

SELECT * FROM Generos;
SELECT * FROM Autores;
SELECT * FROM Livros;