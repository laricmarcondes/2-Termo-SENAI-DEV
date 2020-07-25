-- DEFINIR QUAL BANCO DE DADOS ESTÁ SENDO UTILIZADO
USE SpMedGroup_Tarde;

--PARA INSERIR DADOS
INSERT INTO Clinica (NomeClinica, RazaoSocial, CNPJ)
VALUES	('Clinica Possarle', 'SP Medical Group', '86.400.902/0001-30');

INSERT INTO EnderecoClinica (NomeEndereC, Numero, Cidade, Estado, IdClinica)
VALUES	('Av. Barão de Limeira', '532', 'São Paulo', 'SP', 1);

INSERT INTO Especialidades (NomeEspecialidade)
VALUES	('Acupuntura'),
		('Anestesiologia'),
		('Angiologia'),
		('Cardiologia'),
		('Cirurgia Cardiovascular'),
		('Cirurgia da Mão'),
		('Cirurgia do Aparelho Digestivo'),
		('Cirurgia Geral'),
		('Cirurgia Pediátrica'),
		('Cirurgia Plástica'),
		('Cirurgia Torácica'),
		('Cirurgia Vascular'),
		('Dermatologia'),
		('Radioterapia'),
		('Urologia'),
		('Pediatria'),
		('Psiquiatria');

INSERT INTO TipoUsuario (Titulo)
VALUES	('Administrador'),
		('Medico'),
		('Paciente');

INSERT INTO Usuario (Email, Senha, IdTipoUsuario)
VALUES	('adm@adm.com', 'adm123', 1),
		('ricardo.lemos@spmedicalgroup.com.br', 'ricardo123', 2),
		('roberto.possarle@spmedicalgroup.com.br', 'roberto123', 2),
		('helena.souza@spmedicalgroup.com.br', 'helena123', 2),
		('ligia@gmail.com', 'ligia', 3),
		('alexandre@gmail.com', 'alexandre123', 3),
		('fernando@gmail.com', 'fernando123', 3),
		('henrique@gmail.com', 'henrique123', 3),
		('joao@hotmail.com', 'joao123', 3),
		('bruno@gmail.com', 'bruno123', 3),
		('mariana@gmail.com', 'mariana123', 3);

INSERT INTO Prontuario (Nome, RG, CPF, DataNascimento, Telefone, IdUsuario)
VALUES	('Ligia', '43522543-5', '94839859000', '13/10/1983', '11 3456-7654', 5),
		('Alexandre', '32654345-7', '73556944057', '23/07/2001', '11 98765-6543', 6),
		('Fernando', '54636525-3', '16839338002', '10/10/1978', '11 97208-4453', 7),
		('Henrique', '54366362-5', '14332654765', '13/10/1985', '11 3456-6543', 8),
		('João', '32544444-1', '91305348010', '27/08/1975', '11 11 7656-6377', 9),
		('Bruno', '54566266-7', '79799299004', '21/03/1972', '11 95436-8769', 10),
		('Mariana', '54566266-8', '13771913039', '05/03/2018', '', 11);

INSERT INTO EnderecoProntuario (NomeEnderecoP, Numero, Bairro, Cidade, Estado, CEP, IdProntuario)
VALUES	('Rua Estado de Israel', '240', '', 'São Paulo', 'SP', '04022-000', 1),
		('Av. Paulista', '1578', 'Bela Vista', 'São Paulo', 'SP', '01310-200', 2),
		('Av. Ibirapuera', '2927', 'Indianópolis', 'São Paulo', 'SP', '04029-200', 3),
		('R. Vitória', '120', 'Vila Sao Jorge', 'Barueri', 'SP', '06402-030', 4),
		('R. Ver. Geraldo de Camargo', '66', 'Santa Luzia', ' Ribeirão Pires', 'SP', '09405-380', 5),
		('Alameda dos Arapanés', '945', 'Indianópolis', 'São Paulo', 'SP', '04524-001', 6),
		('R Sao Antonio', '232', 'Vila Universal', 'Barueri', 'SP', '06407-140', 7);

INSERT INTO Medico (NomeMedico, CRM, IdClinica, IdEspecialidade, IdUsuario)
VALUES	('Ricardo Lemos', '54356-SP', 1, 2, 2),
		('Roberto Possarle', '53453-SP', 1, 17, 3),
		('Helena Strada', '65463-SP', 1, 16, 4);

INSERT INTO Situacao (Titulo)
VALUES	('Realizada'),
		('Agendada'),
		('Cancelada');

INSERT INTO Consulta (DataConsulta, IdProntuario, IdMedico, IdSituacao)
VALUES	('20/01/2020 15:00', 7, 3, 1),
		('06/01/2020 10:00', 2, 2, 3),
		('07/01/2020 11:00', 3, 2, 1),
		('06/02/2018 10:00', 2, 2, 1),
		('07/02/2019 11:00', 4, 1, 3),
		('08/03/2020 15:00', 7, 3, 2),
		('09/03/2020 11:00', 4, 1, 2);
		
SELECT * FROM Clinica;
SELECT * FROM EnderecoClinica;
SELECT * FROM Especialidades;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM Prontuario;
SELECT * FROM EnderecoProntuario;
SELECT * FROM Medico;
SELECT * FROM Situacao;
SELECT * FROM Consulta;
