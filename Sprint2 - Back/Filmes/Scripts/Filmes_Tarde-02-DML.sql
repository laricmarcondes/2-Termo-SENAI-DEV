USE Filmes_tarde;

INSERT INTO Generos	(Nome)
VALUES				('Ação')
					,('Drama');
					
INSERT INTO Filmes	(Titulo, IdGenero)
VALUES				('A vida é bela', 2)
					,('Rambo', 1);

INSERT INTO Usuarios (Email, Senha, Permissao)
VALUES				 ('saulo@email.com', '123', 'Comum')
					,('adm@adm.com', '123', 'Administrador');