CREATE DATABASE MicroManu_Tarde;

USE MicroManu_Tarde;

CREATE TABLE TipoConserto (
	IdTipoConserto	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Cliente (
	IdCliente		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Itens(
	IdItens			INT PRIMARY KEY IDENTITY,
	Descricao		VARCHAR (200)
);

CREATE TABLE Colaboradores (
	IdColaboradores	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200),
	Salario			VARCHAR(200)
);

CREATE TABLE Pedidos (
	IdPedido		INT PRIMARY KEY IDENTITY,
	NumeroEquipamento 	VARCHAR(200),
	Entrada 			DATE,
	Saida				DATE,
	IdCliente			INT FOREIGN KEY REFERENCES Cliente (IdCliente),
	IdItem				INT FOREIGN KEY REFERENCES Itens (IdItens),
	IdTipo				INT FOREIGN KEY REFERENCES TipoConserto (IdTipoConserto)
);

CREATE TABLE PedidosColaboradores (
	IdPedido		INT FOREIGN KEY REFERENCES Pedidos (IdPedido),
	IdColaboradores	INT FOREIGN KEY REFERENCES Colaboradores (IdColaboradores)		
);

SELECT * FROM TipoConserto;
SELECT * FROM Cliente;
SELECT * FROM Itens;
SELECT * FROM Colaboradores; 
SELECT * FROM PedidosColaboradores; 