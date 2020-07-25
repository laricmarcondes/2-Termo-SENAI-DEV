USE Optus_tarde;

--	DQL

SELECT * FROM Artistas;

SELECT Nome FROM Artistas;

SELECT Nome,DataLancamento FROM Albuns;

-- Operadores < > =

SELECT * FROM Albuns WHERE IdAlbum = 1;

SELECT * FROM Albuns WHERE IdAlbum > 1;

-- OR

SELECT Nome, Minutos FROM Albuns
WHERE (DataLancamento IS NULL) or (Localizacao IS NULL);

-- LIKE - Comparação de texto

--SELECT IdAlbum, Nome FROM Albuns
--WHERE Nome LIKE 'nome que deseja dentro de uma frase%' -- começo da frase

--SELECT IdAlbum, Nome FROM Albuns
--WHERE Nome LIKE '%nome que deseja dentro de uma frase' -- fim da frase

--SELECT IdAlbum, Nome FROM Albuns
--WHERE Nome LIKE '%nome que deseja dentro de uma frase%' -- fim da frase

--SELECT IdAlbum, Nome FROM Albuns
--WHERE Nome LIKE 'nome que deseja dentro de uma frase' 

-- Ordenação

SELECT Nome FROM Albuns
ORDER BY Nome;

SELECT IdAlbum, Nome, Minutos FROM Albuns
ORDER BY Minutos;

-- Ordenacao invertida (do maior para o menor)

SELECT IdAlbum, Nome, Minutos FROM Albuns
ORDER BY Minutos DESC;

SELECT IdAlbum, Nome, DataLancamento FROM Albuns
ORDER BY DataLancamento ASC;

-- COUNT

SELECT COUNT (IdAlbum) FROM Albuns;

SELECT * FROM Albuns WHERE IdArtistas = 3;

-- USANDO INNER JOIN (JUNÇAO DE DUAS OU MAIS TABELAS)
SELECT  Artistas.Nome, Albuns.Nome FROM Artistas
INNER JOIN Albuns ON Artistas.IdArtistas = Albuns.IdArtistas
WHERE Albuns.IdArtistas = 3;

SELECT * FROM Albuns WHERE DataLancamento = '12/01/2020';

-- INNER JOIN 
SELECT * FROM Artistas
INNER JOIN Albuns ON Artistas.IdArtistas = Albuns.IdArtistas
WHERE DataLancamento = '12/01/2020';

SELECT IdArtistas,IdEstilos FROM Albuns WHERE IdEstilos= 3; -- só aparecerá 1 artista com o mesmo estilo musical

-- INNER JOIN 
SELECT Artistas.Nome as NomeArtista, Estilos.Nome as NomeEstilo
FROM Artistas
INNER JOIN Albuns ON Artistas.IdArtistas = Albuns.IdArtistas
INNER JOIN Estilos ON Albuns.IdEstilos = Estilos.IdEstilos
WHERE Estilos.IdEstilos = 3;

SELECT * FROM Albuns ORDER BY DataLancamento ASC;

-- INNER JOIN 
SELECT Artistas.Nome as NomeArtista, Albuns.Nome as NomeAlbum, Albuns.DataLancamento
FROM Artistas
INNER JOIN Albuns ON Artistas.IdArtistas = Albuns.IdArtistas
ORDER BY DataLancamento ASC;