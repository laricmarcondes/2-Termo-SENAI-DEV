CREATE DATABASE Moda_Tarde;

USE Moda_Tarde;

CREATE TABLE Marcas (
	IdMarca		INT PRIMARY KEY IDENTITY,
	Nome		VARCHAR (200)
);

CREATE TABLE Cores (
	IdCor			INT PRIMARY KEY IDENTITY,
	Descricao		VARCHAR (200)
);

CREATE TABLE Tamanhos (
	IdTamanho		INT PRIMARY KEY IDENTITY,
	Descricao		VARCHAR (200)
);

CREATE TABLE Camisetas (
	IdCamiseta		INT PRIMARY KEY IDENTITY,
	Descricao		VARCHAR(200),
	TipoTecido		VARCHAR(200),
	Ferro			VARCHAR(200),
	IdMarca			INT FOREIGN KEY REFERENCES Marcas (IdMarca)
);

CREATE TABLE CamisetasCores (
	IdCamisetasCores		INT FOREIGN KEY REFERENCES Camisetas (IdCamiseta),
	IdCor			INT FOREIGN KEY REFERENCES Cores (IdCor)
);

CREATE TABLE CamisetasTamanhos (
	IdCamisetasTamnhos		INT FOREIGN KEY REFERENCES Camisetas (IdCamiseta),
	IdTamanho		INT FOREIGN KEY REFERENCES Tamanhos (IdTamanho)
);

SELECT * FROM Marcas;
SELECT * FROM Cores;
SELECT * FROM Tamanhos;
SELECT * FROM Camisetas;
SELECT * FROM CamisetasCores;
SELECT * FROM CamisetasTamanhos;