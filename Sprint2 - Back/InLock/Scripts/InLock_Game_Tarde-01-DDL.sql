CREATE  DATABASE InLock_Games_Tarde;

USE InLock_Games_Tarde;

CREATE TABLE Estudios (
	IdEstudio			INT PRIMARY KEY IDENTITY,
	NomeEstudio			Varchar (255) NOT NULL
);

CREATE TABLE Jogos (
	IdJogo				INT PRIMARY KEY IDENTITY,
	NomeJogo			VARCHAR (255),
	Descricao			VARCHAR (255),
	DataLancamento		DATE,
	Valor				FLOAT,
	IdEstudio			INT FOREIGN KEY REFERENCES Estudios (IdEstudio)
);

CREATE TABLE TiposUsuario (
	IdTipoUsuario		INT PRIMARY KEY IDENTITY,
	Tipo				VARCHAR (255) NOT NULL 
);


CREATE TABLE Usuarios (
IdUsuario				INT PRIMARY KEY IDENTITY,
Email					VARCHAR (200) NOT NULL UNIQUE,
Senha					VARCHAR(200) NOT NULL,
IdTipoUsuario			INT FOREIGN  KEY REFERENCES TiposUsuario (IdTipoUsuario)
);

