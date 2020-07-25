USE T_Peoples;

INSERT INTO Funcionarios (Nome, Sobrenome)
VALUES	('Catarina', 'Strada'),
		('Tadeu', 'Vitelli');

UPDATE Funcionarios
SET	DataNascimento = '20/04/1998'
WHERE IdFuncionario = 1;

UPDATE Funcionarios
SET	DataNascimento = '09/08/1996'
WHERE IdFuncionario = 2;

UPDATE Funcionarios
SET	DataNascimento = '19/05/2000'
WHERE IdFuncionario = 3;

INSERT INTO TipoUsuario (Tipo)
VALUES				 ('Comum'),
					 ('Administrador');

INSERT INTO Usuarios (Email, Senha, Tipo, IdTipoUsuario)
VALUES				 ('lari@email.com', '123', 'Comum', 1),
					 ('adm@email.com', '123', 'Administrador', 2);

SELECT * FROM Funcionarios ;
SELECT * FROM Usuarios ;
SELECT * FROM TipoUsuario ;