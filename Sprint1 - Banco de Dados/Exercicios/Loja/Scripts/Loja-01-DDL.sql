CREATE DATABASE Loja_Tarde;

USE Loja_Tarde;

CREATE TABLE Loja (
	IdLoja			INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Cliente (
	IdCliente		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Categoria (
	IdCategoria		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200),
	IdLoja			INT FOREIGN KEY REFERENCES Loja (IdLoja)
);

CREATE TABLE SubCategoria (
	IdSubCategoria 	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200),
	IdCategoria		INT FOREIGN KEY REFERENCES Categoria (IdCategoria)
);

CREATE TABLE Produto(
	IdProduto		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200),
	Valor			VARCHAR(200),
	IdSubCategoria 	INT FOREIGN KEY REFERENCES SubCategoria (IdSubCategoria)
);

CREATE TABLE Pedidos(
	IdPedidos		INT PRIMARY KEY IDENTITY,
	NrPedido		VARCHAR(200),
	DataPedido		DATE,
	Status			VARCHAR(200),
	IdCliente		INT FOREIGN KEY REFERENCES Cliente (IdCliente)		
);

CREATE TABLE PedidosProdutos (
	IdPedido		INT FOREIGN KEY REFERENCES Pedidos (IdPedidos),
	IdProduto		INT FOREIGN KEY REFERENCES Produto (IdProduto)		
);

SELECT * FROM Loja; 
SELECT * FROM Cliente;
SELECT * FROM Categoria;
SELECT * FROM SubCategoria; 
SELECT * FROM Produto;
SELECT * FROM Pedidos;
SELECT * FROM PedidosProdutos;