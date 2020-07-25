USE MicroManu_Tarde;

INSERT INTO TipoConserto (Nome)
VALUES		('Manutenção'),
			('Limpeza');

INSERT INTO Cliente  (Nome)
VALUES		('Carol'), ('Saulo');

INSERT INTO Itens (Descricao)
VALUES		('Computador'),
			('Notebook'),
			('Video  Game'),
			('Televisão'),
			('Celular');

INSERT INTO Pedidos (NumeroEquipamento, Entrada, Saida, IdCliente, IdItem, IdTipo)
VALUES		('123', '20/jul', '22/jul', 1, 1, 1),
			('321', '21/jul', '', 2, 3, 1),
			('132', '21/jul', '', 2, 4, 2);

INSERT INTO PedidosColaboradores (IdPedido, IdColaboradores)
VALUES		(1, 1),
			(2, 2),
			(2, 3),
			(3, 1);

SELECT * FROM TipoConserto;
SELECT * FROM Cliente;
SELECT * FROM Itens;
SELECT * FROM Colaboradores; 
SELECT * FROM PedidosColaboradores; 