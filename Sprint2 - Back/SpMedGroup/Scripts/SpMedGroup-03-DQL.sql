-- DEFINIR QUAL BANCO DE DADOS ESTÁ SENDO UTILIZADO
USE SpMedGroup_Tarde;

SELECT Titulo FROM TipoUsuario; 

SELECT Prontuario.Nome,
	   DATEDIFF(YY, Prontuario.DataNascimento, GETDATE()) -
		CASE
			WHEN DATEADD(YY, DATEDIFF(YY,Prontuario.DataNascimento,GETDATE()),Prontuario.DataNascimento) 
			> GETDATE() THEN 1
			ELSE 0
		END AS Idade
FROM Prontuario;

SELECT Prontuario.Nome, Prontuario.RG, Prontuario.CPF, Prontuario.DataNascimento, Prontuario.Telefone, Consulta.DataConsulta, Situacao.Titulo
FROM Consulta
INNER JOIN Situacao ON Consulta.IdSituacao = Situacao.IdSituacao
RIGHT JOIN Prontuario ON Consulta.IdProntuario = Prontuario.IdProntuario;

SELECT Prontuario.Nome, Prontuario.DataNascimento, Prontuario.Telefone, Consulta.DataConsulta, Medico.NomeMedico, Situacao.Titulo
FROM Consulta
INNER JOIN Prontuario ON Consulta.IdProntuario = Prontuario.IdProntuario
INNER JOIN Medico  ON Consulta.IdMedico = Medico.IdMedico
INNER JOIN Situacao ON Consulta.IdSituacao = Situacao.IdSituacao;

SELECT Medico.NomeMedico, Medico.CRM, Especialidades.NomeEspecialidade
FROM Medico
INNER JOIN Especialidades ON Medico.IdEspecialidade = Especialidades.IdEspecialidade;

SELECT Medico.NomeMedico, Medico.CRM, Clinica.NomeClinica
FROM Medico
INNER JOIN Clinica ON Medico.IdClinica = Clinica.IdClinica;

SELECT Especialidades.NomeEspecialidade AS Especilidade, COUNT (Medico.NomeMedico) AS QuantidadeMedicos
FROM Medico
INNER JOIN Especialidades ON Medico.IdEspecialidade = Especialidades.IdEspecialidade
GROUP BY Especialidades.NomeEspecialidade;

SELECT Prontuario.IdProntuario,
FORMAT (DataNascimento, 'MM-dd-yyyy') 
AS DataNascimento 
FROM Prontuario;





