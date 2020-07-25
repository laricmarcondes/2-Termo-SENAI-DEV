USE Optus_tarde;

--	DML 

--COMANDO PARA INSERIR DADOS

INSERT INTO TipoUsuario (Nome)
VALUES ('Administrador'), ('Usuário Comum');

INSERT INTO Estilos (Nome)
VALUES ('Pagode'), ('Samba'), ('Rock');

--	ADICIONAR MAIS DADOS ********
INSERT INTO Estilos (Nome)
VALUES ('Pop'), 
	   ('Reggae');
--******************************

INSERT INTO Artistas (Nome)
VALUES ('Anita'), 
	   ('Zeca Pagodinho'),
	   ('Pitty');

--	ADICIONAR MAIS DADOS ********
INSERT INTO Artistas (Nome)
VALUES ('Shawn Mendes'), 
	   ('Edu Ribeiro');
--******************************

INSERT INTO Usuarios (Nome, IdTipoUsuario)
VALUES ('Larissa', 1);

INSERT INTO Albuns (Nome, DataLancamento, Minutos, Localizacao, IdArtistas, IdEstilos)
VALUES ('Equalize', '29/01/2020', 120, 'SP', 3, 3);

--	ADICIONAR MAIS DADOS ********
INSERT INTO Albuns (Nome, DataLancamento, Minutos, Localizacao, IdArtistas, IdEstilos)
VALUES ('Ccccccc', '12/01/2020', 120, 'SP', 4, 4),
	   ('Aaaaaa', '12/04/2019', 110, 'MG', 3, 3),
	   ('Ssssss', '19/08/2019', 130, 'RJ', 2, 2),
	   ('Tttttt', '25/05/2019', 160, 'SP', 1, 1);
--******************************

UPDATE Albuns
SET DataLancamento = '12/01/2020'
WHERE IdAlbum = 1;

--ALTERAR DADOS: Update

--UPDATE Artistas
--SET Nome = 'Zeca Pagodinho'
--WHERE IdArtistas = 2;


--LIMPAR TODOS OS DADOS DA TABELA
--TRUNCATE TABLE nome da tabela;

--MUDAR O NOME EM UMA TABELA
UPDATE Artistas
SET Nome = 'Ariana Grande'
WHERE IdArtistas = 4;

UPDATE Albuns
SET Localizacao = 'BA';

--APAGAR UMA LINHA INTEIRA DA TABELA
DELETE FROM Albuns
WHERE IdAlbum=2;

-- adicionei de novo, pois acabei de apagar esse album á cima 
INSERT INTO Albuns(Nome, DataLancamento, Minutos, Localizacao, IdArtistas, IdEstilos)
VALUES ('Ccccccc', '12/01/2020', 120, 'SP', 4, 4);


SELECT * FROM TipoUsuario;
SELECT * FROM Artistas;
SELECT * FROM Estilos;
SELECT * FROM Usuarios;
SELECT * FROM Albuns;