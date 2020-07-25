CREATE DATABASE Livros_Tarde;

-- Apontar para o banco que quero usar
USE Livros_Tarde;

-- CRIAR TABELAS

CREATE TABLE Autores (
	IdAutor		INT PRIMARY KEY IDENTITY,
	NomeAutor	VARCHAR(200) NOT NULL
);

CREATE TABLE Generos (
	IdGenero	INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) NOT NULL
);

CREATE TABLE Livros (
	IdLivro		INT PRIMARY KEY IDENTITY,
	Titulo		VARCHAR(255),
	IdAutor		INT FOREIGN KEY REFERENCES Autores (IdAutor),
	IdGenero	INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

SELECT * FROM Generos;
SELECT * FROM Autores;
SELECT * FROM Livros;

-- ALTERAR ADICIONANDO UMA NOVA COLUNA
ALTER TABLE Generos
ADD Descricao VARCHAR(255);

-- ALTERAR TIPO DE DADO
ALTER TABLE Generos
ALTER COLUMN Descricao CHAR(100);

--ALTERAR EXCLUINDO UMA COLUNA
ALTER TABLE Generos
DROP COLUMN Descricao;

--EXCLUIR UMA TABELA INTEIRA
--DROP TABLE e o nome da tabela;

--EXCLUIR BANCO DE DADOS
--Precisa entrar em outro banco, por exemplo: USE RoteiroLivro;
--Depois coloca: DROP DATABASE e o nome do banco, exemplo: Biblioteca_Tarde; e executar