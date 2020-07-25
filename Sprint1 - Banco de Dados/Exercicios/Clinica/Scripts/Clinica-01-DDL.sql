CREATE DATABASE Clinica_Tarde;

USE Clinica_Tarde;

CREATE TABLE TipoPet (
	IdTipoPet		INT PRIMARY KEY IDENTITY,
	Titulo			VARCHAR (200)
);

CREATE TABLE Dono (
	IdDono			INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Clinica (
	IdClinica		INT PRIMARY KEY IDENTITY,
	RazaoSocial		VARCHAR (200),
	Endere�o		VARCHAR (200)
);

CREATE TABLE Veterinario (
	IdVeterinario	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200),
	CRMV			VARCHAR(200),
	IdClinica		INT FOREIGN KEY REFERENCES Clinica (IdClinica)
);

CREATE TABLE Ra�a (
	IdRa�a			INT PRIMARY KEY IDENTITY,
	Titulo			VARCHAR(200),
	IdTipoPet		INT FOREIGN KEY REFERENCES TipoPet (IdTipoPet)
);

CREATE TABLE Pet (
	IdPet			INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200),
	Telefone		VARCHAR(200),
	IdDono			INT FOREIGN KEY REFERENCES Dono (IdDono),
	IdRa�a			INT FOREIGN KEY REFERENCES Ra�a(IdRa�a)
);

CREATE TABLE Atendimento (
	IdAtendimento	INT PRIMARY KEY IDENTITY,
	Data			DATE,
	Descri�ao		VARCHAR (200),
	IdVeterinario	INT FOREIGN KEY REFERENCES Veterinario (IdVeterinario),
	IdPet			INT FOREIGN KEY REFERENCES Pet (IdPet)
);

SELECT * FROM TipoPet;
SELECT * FROM Dono;
SELECT * FROM Clinica;
SELECT * FROM Veterinario;
SELECT * FROM Ra�a;
SELECT * FROM Pet;
SELECT * FROM Atendimento;