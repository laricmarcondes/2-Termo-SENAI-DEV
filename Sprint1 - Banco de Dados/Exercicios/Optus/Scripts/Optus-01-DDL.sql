--	DDL
CREATE DATABASE Optus_tarde;

USE Optus_tarde;

CREATE TABLE TipoUsuario (
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL
);

CREATE TABLE Artistas(
	IdArtistas		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL
);

CREATE TABLE Estilos(
	IdEstilos		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL
);

CREATE TABLE Usuarios(
	IdUsuarios		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

CREATE TABLE Albuns (
	IdAlbum			INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL UNIQUE,
	DataLancamento	DATE,
	Minutos			BIGINT,
	Localizacao		VARCHAR(200),
	IdArtistas		INT FOREIGN KEY REFERENCES Artistas (IdArtistas),
	IdEstilos		INT FOREIGN KEY REFERENCES Estilos (IdEstilos)
);

SELECT * FROM TipoUsuario;
SELECT * FROM Artistas;
SELECT * FROM Estilos;
SELECT * FROM Usuarios;
SELECT * FROM Albuns;