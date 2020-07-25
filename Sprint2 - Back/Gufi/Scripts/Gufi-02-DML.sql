-- DEFINE QUAL BANCO DE DADOS ESTÁ SENDO UTILIZADO
USE Gufi_Tarde;

--PARA INSERIR DADOS

INSERT INTO TipoUsuario (TituloTipoUsuario)
VALUES	('Administrador'), ('Comum');

INSERT INTO TipoEvento (TituloTipoEvento)
VALUES	('C#'), ('React'), ('SQL');

INSERT INTO Instituicao (CNPJ, NomeFantasia, Endereco)
VALUES	('11111111111111', 'Escola SENAI de Informática', 'Rua Barão de Limeira, 538'),
		('22222222222222', 'Escola Mundo Virtual', 'Rua Paulo Azevedo, 298');

INSERT INTO Usuario (NomeUsuario, Email, Senha, Genero, DataNascimento, IdTipoUsuario)
VALUES	('Administrador', 'adm@adm.com', 'adm123', 'Não infomado', '06/02/2020', 1),
		('Carol', 'carol@email.com', 'carol123', 'Feminino', '06/02/2020', 2),
		('Saulo', 'saulo@email.com', 'saulo123', 'Masculino', '06/02/2020', 2);

INSERT INTO Evento (NomeEvento, DataEvento, Descricao, AcessoLivre, IdInstituicao, IdTipoEvento)
VALUES	('Introdução ao C#', '07/02/2020', 'Conceitos sobre os pilares da programação orientada a objeto', 1, 1, 1),
		('Ciclo de vida', '07/02/2020', 'Como utilizar o ciclo da vida com Reacts', 0, 1, 2),
		('Optimização de banco de dados', '07/02/2020', 'Aplicação de índices clusterizados e não clusterizados', 1, 1, 3);

INSERT INTO Presenca (IdUsuario, IdEvento, Situacao)
VALUES	(2, 2, 'Agendada'),
		(2, 3, 'Confirmada'),
		(1, 1, 'Não compareceu');

SELECT * FROM TipoUsuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM Presenca;