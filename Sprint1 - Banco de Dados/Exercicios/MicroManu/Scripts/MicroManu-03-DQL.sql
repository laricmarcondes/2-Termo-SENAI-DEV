USE MicroManu_Tarde;

-- Exibir todos os pedidos com seus respectivos campos preenchidos (sem ID)

SELECT * FROM Pedidos;

SELECT NumeroEquipamento, Entrada, Saida, Cliente.Nome, Itens.Descricao, TipoConserto.Nome
FROM Cliente
INNER JOIN Pedidos ON Cliente.IdCliente = Pedidos.IdCliente
INNER JOIN Itens ON Pedidos.IdCliente = Itens.IdItens
INNER JOIN TipoConserto ON Itens.IdItens = TipoConserto.IdTipoConserto