USE Locadora_Tarde;

SELECT * FROM Aluguel;

-- todos os alugueis com os campos preenchidos sem id

SELECT DataInicio, DataFim, Cliente.Nome, Veiculo.Placa
FROM Cliente
INNER JOIN Aluguel ON Cliente.IdCliente = Aluguel.IdCliente
INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo

