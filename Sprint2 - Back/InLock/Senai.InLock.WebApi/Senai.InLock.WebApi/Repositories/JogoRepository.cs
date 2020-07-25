using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{

    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        private string stringConexao = "Data Source=DEV3\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna uma lista dos jogos</returns>
        public List<JogoDomain> Listar()
        {
            // Cria uma lista jogos onde serão armazenados os dados
            List<JogoDomain> jogos = new List<JogoDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, NomeEstudio FROM Jogos " +
                                        "INNER JOIN Estudios ON Jogos.IdJogo = Estudios.IdEstudio";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto estudio 
                        JogoDomain jogo = new JogoDomain
                        {
                            // Atribui à propriedade IdJogo o valor da coluna "IdJogo" da tabela do banco
                            IdJogo = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            NomeJogo = rdr["NomeJogo"].ToString(),

                            // Atribui à propriedade Descricao o valor da coluna "Descricao" da tabela do banco
                            Descricao = rdr["Descricao"].ToString(),

                            // Atribui à propriedade DataLancamento o valor da coluna "DataLancamento" da tabela do banco
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            // Atribui à propriedade Valor o valor da coluna "Valor" da tabela do banco
                            Valor = Convert.ToSingle(rdr["Valor"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            NomeEstudio = rdr["NomeEstudio"].ToString(),

                            // Atribui à propriedade IdEstudio o valor da coluna "IdEstudio" da tabela do banco
                            IdEstudio = Convert.ToInt32(rdr[0]),
                        };

                        // Adiciona o jogo criado à lista jogos
                        jogos.Add(jogo);
                    }
                }
            }
            // Retorna a lista de funcionarios
            return jogos;
        }

        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        public void Cadastrar(JogoDomain jogo)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor) VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor)";

                // Declara o comando passando a query e a conexão
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                // Passa o valor do parâmetro
                cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);
                cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                cmd.Parameters.AddWithValue("@Valor", jogo.Valor);

                // Abre a conexão com o banco de dados
                con.Open();

                // Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado que será atualizado</param>
        public void AtualizarIdUrl(int id, JogoDomain jogo)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Jogos SET NomeJogo, Descricao, DataLancamento, Valor = @NomeJogo, @Descricao, @DataLancamento, @Valor WHERE IdJogo = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Jogos WHERE IdJogo = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int idJogo)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdJogo, NomeJogo FROM Jogos WHERE IdJogo = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", idJogo);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto jogo 
                        JogoDomain nomeJogo = new JogoDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdJogo = Convert.ToInt32(rdr["IdJogo"])
                            ,
                            NomeJogo = rdr["NomeJogo"].ToString()
                        };

                        // Retorna o tipo buscado
                        return nomeJogo;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="JogoAtualizado">Objeto UsuarioAtualizado que será alterado</param>
        public void Atualizar(int id, JogoDomain JogoAtualizado)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Jogos " +
                                     "SET NomeJogo = @NomeJogo, Descricao = @Descricao, DataLancamento = @DataLancamento, Valor = @Valor, IdEstudio = @IdEstudio " +
                                     "WHERE IdJogo = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeJogo", JogoAtualizado.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", JogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", JogoAtualizado.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", JogoAtualizado.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", JogoAtualizado.IdEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdCorpo(JogoDomain jogo)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE Jogos " +
                                     "SET NomeJogo = @NomeJogo, Descricao = @Descricao, DataLancamento = @DataLancamento, Valor = @Valor, IdEstudio = @IdEstudio " +
                                     "WHERE IdJogo = @ID";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
