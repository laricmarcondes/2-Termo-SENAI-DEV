USE Livros_Tarde;

-- Selecionar todos os autores;
-- Selecionar todos os gêneros;
-- Selecionar todos os livros;
-- Selecionar todos os livros e seus respectivos autores;
-- Selecionar todos os livros e seus respectivos gêneros;
-- Selecionar todos os livros e seus respectivos autores e gêneros;

SELECT NomeAutor FROM Autores;

SELECT * FROM Generos;

SELECT Titulo FROM Livros;

SELECT Nome FROM Generos;

SELECT Titulo, IdAutor FROM Livros;
SELECT Titulo, Autores.NomeAutor
FROM Autores
INNER JOIN Livros ON Autores.IdAutor = Livros.IdAutor

SELECT Titulo, IdGenero FROM Livros;
SELECT Titulo, Generos.Nome
FROM Generos
INNER JOIN Livros ON Generos.IdGenero = Livros.IdGenero

SELECT Titulo, IdGenero, IdAutor FROM Livros;
SELECT Titulo, Generos.Nome, Autores.NomeAutor
FROM Generos
INNER JOIN Livros ON Generos.IdGenero = Livros.IdGenero
INNER JOIN Autores ON Livros.IdAutor = Autores.IdAutor

