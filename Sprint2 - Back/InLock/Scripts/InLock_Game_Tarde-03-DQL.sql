USE InLock_Games_Tarde;

SELECT * FROM Usuarios;
SELECT * FROM  Estudios;
SELECT * FROM Jogos;


SELECT Jogos.NomeJogo , Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio
FROM Jogos 
INNER JOIN Estudios on Jogos.IdJogo = Estudios.IdEstudio;


SELECT Estudios.NomeEstudio,Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor
FROM Estudios 
LEFT JOIN Jogos on Estudios.IdEstudio = Jogos.IdJogo;

SELECT U.IdUsuario, U.Email, U.IdTipoUsuario, TU.Tipo FROM Usuarios U
INNER JOIN TiposUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
WHERE U.Email = 'cliente@cliente.com' AND U.Senha = 'cliente';

SELECT   Jogos.IdJogo,  Jogos.NomeJogo , Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio
FROM Jogos 
INNER JOIN Estudios on Jogos.IdJogo = Estudios.IdEstudio 
WHERE Jogos.IdJogo = '1' ;


SELECT   Estudios.IdEstudio,  Estudios.NomeEstudio,Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor
FROM Estudios 
LEFT JOIN Jogos on Estudios.IdEstudio = Jogos.IdJogo
WHERE Estudios.IdEstudio = '2' ;
