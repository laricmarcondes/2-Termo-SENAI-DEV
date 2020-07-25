USE Moda_Tarde;

INSERT INTO Marcas (Titulo)
VALUES		('SENAIZITO'), ('Khelf'), ('Hering');

INSERT INTO Cores (Descricao)
VALUES		('Branco'), ('Vermelho'), ('Azul'), ('Roxo'), ('Verde');

INSERT INTO Tamanhos (Descricao)
VALUES		('P', 'M', 'G', 'GG');

INSERT INTO Camisetas (Descricao, TipoTecido, Ferro, IdMarca)
VALUES		('Camiseta Top', 'Algodão', '1', 2),
			('Ícone do SENAI', 'Malha', '0', 1),
			('Outlet SENAI', 'Algodão', '1', 1);

INSERT INTO CamisetasCores (IdCamiseta, IdCor)
VALUES		(3, 4),
			(3, 1),
			(1, 3);

INSERT INTO CamisetasTamanhos (IdCamiseta, IdTamanho)
VALUES		(3, 1),		
			(3, 2),
			(3, 4),
			(1, 2);

SELECT * FROM Marcas;
SELECT * FROM Cores;
SELECT * FROM Tamanhos;
SELECT * FROM Camisetas;
SELECT * FROM CamisetasCores;
SELECT * FROM CamisetasTamanhos;