CREATE DATABASE Senatur_Tarde;

USE Senatur_Tarde;

CREATE TABLE Pacotes (
	IdPacote			INT PRIMARY KEY IDENTITY,
	NomePacote			VARCHAR (255) NOT NULL,
	Descricao			VARCHAR (800) NOT NULL,
	DataIda				DATETIME NOT NULL,
	DataVolta			DATETIME NOT NULL,
	Valor				DECIMAL (18,2) NOT NULL,
	Ativo				VARCHAR (255) NOT NULL,
	NomeCidade			VARCHAR (255) NOT NULL
);

CREATE TABLE TiposUsuario (
	IdTipoUsuario		INT PRIMARY KEY IDENTITY,
	Titulo				VARCHAR (255) NOT NULL 
);


CREATE TABLE Usuarios (
IdUsuario				INT PRIMARY KEY IDENTITY,
Email					VARCHAR (200) NOT NULL,
Senha					VARCHAR(200) NOT NULL,
IdTipoUsuario			INT FOREIGN  KEY REFERENCES TiposUsuario (IdTipoUsuario)
);

SELECT * FROM Pacotes;
SELECT * FROM TiposUsuario;
SELECT * FROM Usuarios;