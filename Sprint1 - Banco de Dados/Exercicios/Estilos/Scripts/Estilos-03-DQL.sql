USE Estilos_Tarde;

-- Selecionar todos os registros da tabela de artista;
-- Selecionar todos os registros da tabela de estilos;
-- Selecionar todos os registros da tabela de artistas e seus respectivo estilos;

SELECT * FROM Artistas;

SELECT * FROM EstilosMusicais;

SELECT Artistas.Nome, EstilosMusicais.Nome
FROM EstilosMusicais
INNER JOIN Artistas ON EstilosMusicais.IdEstiloMusical = Artistas.IdArtista