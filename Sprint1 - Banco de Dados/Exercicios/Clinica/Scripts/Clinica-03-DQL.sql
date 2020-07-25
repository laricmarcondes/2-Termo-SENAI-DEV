USE Clinica_Tarde;

SELECT * FROM Atendimento;

SELECT Data, Descricao, Veterinario.Nome, Pet.Nome
FROM Veterinario
INNER JOIN Atendimento ON Veterinario.IdVeterinario = Atendimento.IdVeterinario
INNER JOIN Pet ON Atendimento.IdPet = Pet.IdPet