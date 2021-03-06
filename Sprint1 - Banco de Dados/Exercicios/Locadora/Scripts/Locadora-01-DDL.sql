CREATE DATABASE Locadora_Tarde;

USE Locadora_Tarde;

CREATE TABLE Empresa (
	IdEmpresa	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Marca (
	IdMarca		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Cliente (
	IdCliente	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200),
	CPF				VARCHAR (200)
);

CREATE TABLE Modelo (
	IdModelo		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200),
	IdMarca			INT FOREIGN KEY REFERENCES Marca (IdMarca)
);

CREATE TABLE Veiculo (
	IdVeiculo		INT PRIMARY KEY IDENTITY,
	Placa			VARCHAR(200),
	IdEmpresa		INT FOREIGN KEY REFERENCES Empresa (IdEmpresa),
	IdModelo		INT FOREIGN KEY REFERENCES Modelo (IdModelo)
);

CREATE TABLE Aluguel (
	IdAluguel		INT PRIMARY KEY IDENTITY,
	DataInicio		DATE,
	DataFim			DATE,
	IdCliente		INT FOREIGN KEY REFERENCES Cliente (IdCliente),
	IdVeiculo		INT FOREIGN KEY REFERENCES Veiculo (IdVeiculo)
);

SELECT * FROM Empresa;
SELECT * FROM Cliente;
SELECT * FROM Veiculo;
SELECT * FROM Aluguel;
SELECT * FROM Modelo;
SELECT * FROM Marca;