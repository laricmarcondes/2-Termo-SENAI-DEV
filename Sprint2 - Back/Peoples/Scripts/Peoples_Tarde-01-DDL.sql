CREATE DATABASE T_Peoples;

USE T_Peoples;

CREATE TABLE Funcionarios(
	IdFuncionario		INT PRIMARY KEY IDENTITY,
	Nome				VARCHAR (255) NOT NULL,
	Sobrenome			VARCHAR (255) NOT NULL 
);

ALTER TABLE Funcionarios
ADD DataNascimento		DATE ;

CREATE TABLE TipoUsuario(
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	Tipo			VARCHAR (255) NOT NULL,
);

CREATE TABLE Usuarios(
	IdUsuario	INT PRIMARY KEY IDENTITY,
	Email		VARCHAR (255) NOT NULL UNIQUE,
	Senha		VARCHAR (255) NOT NULL,
	Tipo	VARCHAR (255) NOT NULL,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);



SELECT * FROM Funcionarios ;
SELECT * FROM Usuarios ;
SELECT * FROM TipoUsuario ;

