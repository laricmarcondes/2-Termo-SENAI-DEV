USE Departamentos_Tarde;

INSERT INTO Departamentos (Nome)
VALUES		('Design'), ('Desenvolvimento');

INSERT INTO Habilidades (Nome)
VALUES		('HTML'),
			('Desenhar interfaces'),
			('Java'),
			('CSS'),
			('Kotlin');

INSERT INTO Funcionarios (Nome, CPF, Salario, IdDepartamento)
VALUES		('Erik', '123.321.456.66' , '1000', 1),
			('Helena', '321.123.654.44' , '1000', 2),
			('Jucelino', '987.789.654.44' , '2000', 2);

INSERT INTO FuncionariosHabilidades (IdFuncionario, IdHabilidade)
VALUES		(1, 1),
			(2, 1),
			(1, 2),
			(3, 5),
			(3, 2),
			(2, 4);

SELECT * FROM Departamentos;
SELECT * FROM Habilidades;
SELECT * FROM Funcionarios ;
SELECT * FROM FuncionariosHabilidades;
