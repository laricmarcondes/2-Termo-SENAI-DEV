CREATE DATABASE Departamentos_Tarde

USE Departamentos_Tarde;

CREATE TABLE Departamentos (
	IdDepartamento		INT PRIMARY KEY IDENTITY,
	Nome				VARCHAR (200)
);

CREATE TABLE Habilidades (
	IdHabilidade		INT PRIMARY KEY IDENTITY,
	Nome				VARCHAR (200)
);

CREATE TABLE Funcionarios (
	IdFuncionario		INT PRIMARY KEY IDENTITY,
	Nome				VARCHAR (200),
	CPF					VARCHAR (200),
	Salario				VARCHAR (200),
	IdDepartamento		INT FOREIGN KEY REFERENCES Departamentos(IdDepartamento)
);

CREATE TABLE FuncionariosHabilidades (
	IdFuncionario		INT FOREIGN KEY REFERENCES Funcionarios (IdFuncionario),
	IdHabilidade		INT FOREIGN KEY REFERENCES Habilidades (IdHabilidade)
);

SELECT * FROM Departamentos;
SELECT * FROM Habilidades;
SELECT * FROM Funcionarios ;
SELECT * FROM FuncionariosHabilidades;