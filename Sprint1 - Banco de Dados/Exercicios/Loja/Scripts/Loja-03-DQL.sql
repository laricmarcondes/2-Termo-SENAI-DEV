USE Loja_Tarde;

-- Exibir todos os pedidos com seus respectivos campos preenchidos (sem ID)

SELECT * FROM Pedidos;

SELECT NrPedido, DataPedido, Status, Cliente.Nome
FROM Cliente
INNER JOIN Pedidos ON Cliente.IdCliente = Pedidos.IdCliente