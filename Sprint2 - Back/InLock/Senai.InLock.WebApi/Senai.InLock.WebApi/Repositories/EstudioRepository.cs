using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        private string stringConexao = "Data Source=DEV3\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Retorna uma lista dos estúdios</returns>
        public List<EstudioDomain> Listar()
        {
            // Cria uma lista estudios onde serão armazenados os dados
            List<EstudioDomain> estudios = new List<EstudioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudios";

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
                        EstudioDomain estudio = new EstudioDomain
                        {
                            // Atribui à propriedade IdEstudio o valor da coluna "IdEstudio" da tabela do banco
                            IdEstudio = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        // Adiciona o estudio criado à lista estudios
                        estudios.Add(estudio);
                    }
                }
            }
            // Retorna a lista de funcionarios
            return estudios;
        }
    }
}
