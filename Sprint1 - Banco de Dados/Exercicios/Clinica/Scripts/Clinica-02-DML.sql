USE Clinica_Tarde;

INSERT INTO TipoPet (Titulo)
VALUES		('Cachorro'), ('Gato');

INSERT INTO Dono (Nome)
VALUES		('Carol'), ('Saulo');

INSERT INTO Clinica (RazaoSocial, Endereço)
VALUES		('ClinicaVeterinaria', 'Alameda Barão de Limeira, 532');

INSERT INTO Veterinario (Nome, CRMV,  IdClinica)
VALUES		('Pablo', '123', 1);

INSERT INTO Raça (Titulo, IdTipoPet)
VALUES		('Siamês', 2),
			('Persa', 2);

INSERT INTO Pet (Nome, Telefone, IdDono, IdRaça)
VALUES		('Lua', '9999-9999', 1, 2),
			('Jefferson', '9999-9999', 1, 2);

INSERT INTO Atendimento (Data, Descriçao, IdVeterinario, IdPet)
VALUES		('27/jan', 'Tudo em ordem', 1, 2),
			('28/jan', 'Doença grave detectada', 1, 2);

SELECT * FROM TipoPet;
SELECT * FROM Dono;
SELECT * FROM Clinica;
SELECT * FROM Veterinario;
SELECT * FROM Raça;
SELECT * FROM Pet;
SELECT * FROM Atendimento;