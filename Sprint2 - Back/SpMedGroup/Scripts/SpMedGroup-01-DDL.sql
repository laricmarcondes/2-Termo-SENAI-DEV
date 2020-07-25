-- CRIAR O BANCO DE DADOS
CREATE DATABASE SpMedGroup_Tarde;

-- DEFINE QUAL BANCO DE DADOS ESTÁ SENDO UTILIZADO
USE SpMedGroup_Tarde;

-- CRIAR AS TABELAS DO BANCO DE DADOS
CREATE TABLE Clinica  (
	IdClinica			INT PRIMARY KEY IDENTITY,
	NomeClinica			VARCHAR (200) NOT NULL,
	RazaoSocial			VARCHAR (200) NOT NULL,
	CNPJ				VARCHAR (200) NOT NULL UNIQUE
);

CREATE TABLE EnderecoClinica (
	IdEnderecoClinica	INT PRIMARY KEY IDENTITY,
	NomeEndereC			VARCHAR (200) NOT NULL,
	Numero				CHAR (6) NOT NULL,
	Cidade				VARCHAR (200) NOT NULL,
	Estado				VARCHAR (200) NOT NULL,
	IdClinica			INT FOREIGN KEY REFERENCES Clinica (IdClinica)
);

CREATE TABLE Especialidades (
	IdEspecialidade		INT PRIMARY KEY IDENTITY,
	NomeEspecialidade	VARCHAR (200) NOT NULL
);

CREATE TABLE TipoUsuario (
	IdTipoUsuario		INT PRIMARY KEY IDENTITY,
	Titulo				VARCHAR (200) NOT NULL
);

CREATE TABLE Usuario (
	IdUsuario			INT PRIMARY KEY IDENTITY,
	Email				VARCHAR (255) NOT NULL UNIQUE,
	Senha				VARCHAR (255) NOT NULL,
	IdTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

CREATE TABLE Prontuario (
	IdProntuario		INT PRIMARY KEY IDENTITY,
	Nome				VARCHAR (200) NOT NULL UNIQUE,
	RG					CHAR (10) NOT NULL UNIQUE,
	CPF					CHAR (12) NOT NULL UNIQUE,
	DataNascimento		DATETIME2 NOT NULL,
	Telefone			CHAR (16) NOT NULL UNIQUE,
	IdUsuario			INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
);

CREATE TABLE EnderecoProntuario (
	IdEnderecoProntuario	INT PRIMARY KEY IDENTITY,
	NomeEnderecoP		VARCHAR (200) NOT NULL,
	Numero				CHAR (6) NOT NULL,
	Bairro				VARCHAR (200),
	Cidade				VARCHAR (200) NOT NULL,
	Estado				VARCHAR (200) NOT NULL,
	CEP					CHAR (9) NOT NULL,
	IdProntuario		INT FOREIGN KEY REFERENCES Prontuario (IdProntuario)
);

CREATE TABLE Medico (
	IdMedico			INT PRIMARY KEY IDENTITY,
	NomeMedico			VARCHAR (200) NOT NULL UNIQUE,
	CRM					CHAR (10) NOT NULL UNIQUE,
	IdClinica			INT FOREIGN KEY REFERENCES Clinica (IdClinica),
	IdEspecialidade		INT FOREIGN KEY REFERENCES Especialidades (IdEspecialidade),
	IdUsuario			INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
);

CREATE TABLE Situacao (
	IdSituacao			INT PRIMARY KEY IDENTITY,
	Titulo				VARCHAR (200) NOT NULL
);

CREATE TABLE Consulta (
	IdConsulta			INT PRIMARY KEY IDENTITY,
	DataConsulta		DATETIME2 NOT NULL,
	IdProntuario		INT FOREIGN KEY REFERENCES Prontuario (IdProntuario),
	IdMedico			INT FOREIGN KEY REFERENCES Medico (IdMedico),
	IdSituacao			INT FOREIGN KEY REFERENCES Situacao (IdSituacao)
);

SELECT * FROM Clinica;
SELECT * FROM EnderecoClinica;
SELECT * FROM Especialidades;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM Prontuario;
SELECT * FROM EnderecoProntuario;
SELECT * FROM Medico;
SELECT * FROM Situacao;
SELECT * FROM Consulta;
