USE Clinica_Tarde;

INSERT INTO TipoPet (Titulo)
VALUES		('Cachorro'), ('Gato');

INSERT INTO Dono (Nome)
VALUES		('Carol'), ('Saulo');

INSERT INTO Clinica (RazaoSocial, Endere�o)
VALUES		('ClinicaVeterinaria', 'Alameda Bar�o de Limeira, 532');

INSERT INTO Veterinario (Nome, CRMV,  IdClinica)
VALUES		('Pablo', '123', 1);

INSERT INTO Ra�a (Titulo, IdTipoPet)
VALUES		('Siam�s', 2),
			('Persa', 2);

INSERT INTO Pet (Nome, Telefone, IdDono, IdRa�a)
VALUES		('Lua', '9999-9999', 1, 2),
			('Jefferson', '9999-9999', 1, 2);

INSERT INTO Atendimento (Data, Descri�ao, IdVeterinario, IdPet)
VALUES		('27/jan', 'Tudo em ordem', 1, 2),
			('28/jan', 'Doen�a grave detectada', 1, 2);

SELECT * FROM TipoPet;
SELECT * FROM Dono;
SELECT * FROM Clinica;
SELECT * FROM Veterinario;
SELECT * FROM Ra�a;
SELECT * FROM Pet;
SELECT * FROM Atendimento;