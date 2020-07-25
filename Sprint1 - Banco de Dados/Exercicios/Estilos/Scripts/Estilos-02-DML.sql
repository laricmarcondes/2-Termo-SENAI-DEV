USE Estilos_Tarde;

INSERT INTO EstilosMusicais (Nome, Descricao)
VALUES ('Samba','Estilo Musical'),
	   ('Jazz', 'Estilo top'),
	   ('Pop', 'Estilo popular');

INSERT INTO Artistas (Nome,IdEstiloMusical) 
VALUES ('Zeca Pagodinho',2),
	   ('Frank',3);

SELECT * FROM EstilosMusicais;
SELECT * FROM Artistas;

-- UPDATE ALTERAR DADOS DE DENTRO DAS TABELAS
UPDATE Artistas
SET Nome = 'Alcione'
WHERE IdArtista = 1;

UPDATE Artistas
SET IdEstiloMusical = 1
WHERE IdArtista = 3;