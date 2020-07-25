USE Departamentos;

-- Selecionar todos os funcionários.
-- Selecionar todas as habilidade.
-- Selecionar todos os departamentos.
-- Selecionar todos os funcionários com seus respectivos departamentos

SELECT Nome FROM Funcionarios;

SELECT Nome FROM Habilidades;

SELECT Nome FROM Departamentos;

SELECT Funcionarios.Nome, Departamentos.Nome
FROM Funcionarios
INNER JOIN FuncionariosHabilidades ON Funcionarios.IdFuncionario = Funcionarios.IdFuncionario
INNER JOIN Departamentos ON FuncionariosHabilidades.IdFuncionario = Departamentos.IdDepartamento