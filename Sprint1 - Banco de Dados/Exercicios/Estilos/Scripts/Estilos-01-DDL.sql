CREATE DATABASE Estilos_Tarde;

--Aponta o banco de dados que vou usar 
USE Estilos_Tarde;;

--CRIAR TABELA 
CREATE TABLE EstilosMusicais (
	IdEstiloMusical		INT PRIMARY KEY IDENTITY,
	Nome				VARCHAR(200)
);

--CRIAR TABELA 
CREATE TABLE Artistas(
	IdArtista		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200),
	IdEstiloMusical	INT FOREIGN KEY REFERENCES EstilosMusicais (IdEstiloMusical) 
);

--Alterar Adicionar novo atributo
ALTER TABLE EstilosMusicais
ADD Descricao VARCHAR(200);


SELECT * FROM EstilosMusicais;
SELECT * FROM Artistas;