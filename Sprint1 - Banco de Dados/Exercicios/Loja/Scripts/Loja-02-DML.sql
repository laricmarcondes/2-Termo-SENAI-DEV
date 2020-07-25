USE Loja_Tarde;

INSERT INTO Loja (Nome)
VALUES		('SenaiShop');
	
INSERT INTO Cliente  (Nome)
VALUEs		('Fernando'), ('Helena');

INSERT INTO Categoria (Nome, IdLoja)
VALUES		('Cursos', 1),
			('Acessorios', 1);

INSERT INTO SubCategoria (Nome,  IdCategoria)
VALUES		('Informática Básica', 1),
			('Desenvolvimento', 1),
			('Meio Ambiente', 1),
			('Camisetas', 2);

INSERT INTO Produto (Nome, Valor, IdSubCategoria)
VALUES		('Copo para Café', '25', 3),
			('Jaqueta', '100', 4),
			('Excel Básico', '350', 1),
			('C#', '700', 2);

INSERT INTO Pedidos (NrPedido, DataPedido, Status, IdCliente)
VALUES		('5455514', '22/01/2019', 'Em Andamento', 1),
			('23232', '22/01/2019', 'Entregue', 2);

INSERT INTO PedidosProdutos (IdPedido, IdProduto)
VALUES		(1, 1),
			(1, 2),
			(2, 3),
			(2, 4);

SELECT * FROM Loja; 
SELECT * FROM Cliente;
SELECT * FROM Categoria;
SELECT * FROM SubCategoria; 
SELECT * FROM Produto;
SELECT * FROM Pedidos;
SELECT * FROM PedidosProdutos;