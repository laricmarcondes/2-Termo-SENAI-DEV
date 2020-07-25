-- LISTAR TODOS OS USUÁRIOS CADASTRADOS (NOME, EMAIL, TIPO, DATA DE NASCIMENTO, GENERO)
-- LISTAR TODAS AS INSTITUIÇÕES CADASTRADAS (CNPJ, NOME FANTASIA, ENDERECO)
-- LISTAR TODOS OS TIPOS DE EVENTOS (TITULO)
-- APLICAR A JUNÇÃO DE TABELAS EM TODAS AS CONSULTAS PARA QUE SEJAM EXIBIDOS OS DADOS DOS REGISTROS E NÃO OS IDENTIFICADORES
-- LISTAR APENAS OS EVENTOS QUE SÃO PÚBLICOS (NOME EVENTO, TIPO EVENTO, DATA, PUBLICO OU PRIVADO, DESCRICAO, DADOS DA INSTITUICAO
-- LISTAR TODOS OS EVENTOS QUE UM DETERMINADO USUÁRIO PARTICIPA (NOME EVENTO, TIPO EVENTO, DTA, PUBLICO OU PRIVADO, DESCRICAO, DADOS DA INSTITUICAO, DADOS DO USUARIO
-- APLICAR A JUNÇÃO DE TABELAS EM TODAS AS CONSULTAS PARA QUE SEJAM EXIBIDOS OS DADOS DOS REGISTROS E NÃO OS IDENTIFICADORES


--SELECT DataInicio, DataFim, Cliente.Nome, Veiculo.Placa
--FROM Cliente
--INNER JOIN Aluguel ON Cliente.IdCliente = Aluguel.IdCliente
--INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo


-- CRIAR CONSULTA

use Gufi_Tarde;

SELECT * FROM Usuario, TipoUsuario;

SELECT Usuario.NomeUsuario, Usuario.Email, Usuario.Genero, Usuario.DataNascimento, TipoUsuario.TituloTipoUsuario
FROM Usuario
INNER JOIN TipoUsuario ON Usuario.IdUsuario = TipoUsuario.IdTipoUsuario

SELECT * FROM Instituicao;

SELECT Instituicao.CNPJ, Instituicao.NomeFantasia, Instituicao.Endereco
FROM Instituicao;

SELECT * FROM TipoEvento;

SELECT TipoEvento.TituloTipoEvento 
FROM TipoEvento;

-- USANDO MAIS DE UM INNER JOIN 

SELECT Evento.NomeEvento, TipoEvento.TituloTipoEvento, Evento.DataEvento, Evento.AcessoLivre, Evento.Descricao, 
Instituicao.CNPJ, Instituicao.Endereco, Instituicao.NomeFantasia
FROM Instituicao
INNER JOIN Evento ON Instituicao.IdInstituicao = Evento.IdInstituicao
INNER JOIN TipoEvento ON Evento.IdEvento = TipoEvento.IdTipoEvento
WHERE Evento.AcessoLivre = 1;

SELECT Evento.NomeEvento, TipoUsuario.TituloTipoUsuario, Evento.NomeEvento, Evento.DataEvento, Evento.Descricao, Evento.AcessoLivre,
Instituicao.CNPJ, Instituicao.Endereco, Instituicao.NomeFantasia, Usuario.NomeUsuario, Usuario.DataNascimento, 
Usuario.Email, Usuario.Genero, TipoEvento.TituloTipoEvento
FROM Presenca
INNER JOIN Usuario ON Presenca.IdUsuario = Usuario.IdUsuario
INNER JOIN Evento ON Presenca.IdEvento = Evento.IdEvento
INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario
INNER JOIN TipoEvento ON TipoEvento.IdTipoEvento = Evento.IdTipoEvento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
WHERE Usuario.IdUsuario = 2;

-- EXTRAS

SELECT * FROM Evento;

SELECT Evento.NomeEvento, Evento.DataEvento, Evento.Descricao, Evento.NomeEvento, Instituicao.NomeFantasia,
CASE 
	WHEN AcessoLivre = '1' THEN 'Público'
	WHEN AcessoLivre = '0' THEN 'Privado'
END AS TipoAcesso
FROM Evento
INNER JOIN Instituicao ON  Evento.IdEvento = Instituicao.IdInstituicao

SELECT Evento.NomeEvento, TipoUsuario.TituloTipoUsuario, Evento.NomeEvento, Evento.DataEvento, Evento.Descricao, Evento.AcessoLivre,
Instituicao.CNPJ, Instituicao.Endereco, Instituicao.NomeFantasia, Usuario.NomeUsuario, Usuario.DataNascimento, 
Usuario.Email, Usuario.Genero, TipoEvento.TituloTipoEvento
FROM Presenca
INNER JOIN Usuario ON Presenca.IdUsuario = Usuario.IdUsuario
INNER JOIN Evento ON Presenca.IdEvento = Evento.IdEvento
INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario
INNER JOIN TipoEvento ON TipoEvento.IdTipoEvento = Evento.IdTipoEvento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
WHERE (Usuario.IdUsuario = 2)
AND (Presenca.Situacao = 'Confirmada');

SELECT Usuario.NomeUsuario, Usuario.Email, Usuario.Genero, TipoUsuario.TituloTipoUsuario, 
		DATEDIFF(YY, Usuario.DataNascimento, GETDATE()) -
		CASE
			WHEN DATEADD(YY, DATEDIFF(YY,Usuario.DataNascimento,GETDATE()),Usuario.DataNascimento) 
			> GETDATE() THEN 1
			ELSE 0
		END AS Idade
FROM
Usuario
INNER JOIN
TipoUsuario
ON TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario;


