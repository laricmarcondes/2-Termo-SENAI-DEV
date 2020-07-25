using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        private string stringConexao = "Data Source=DEV3\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Lista todos os tiposUsuarios
        /// </summary>
        /// <returns>Retorna uma lista dos tiposUsuarios</returns>
        public List<TipoUsuarioDomain> Listar()
        {
            // Cria uma lista tipoUsuarios onde serão armazenados os dados
            List<TipoUsuarioDomain> tipoUsuarios = new List<TipoUsuarioDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdTipoUsuario, Tipo FROM TiposUsuario";

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
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            // Atribui à propriedade IdTipoUsuario o valor da coluna "IdTipoUsuario" da tabela do banco
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade Tipo o valor da coluna "Tipo" da tabela do banco
                            Tipo = rdr["Tipo"].ToString()
                        };

                        // Adiciona o estudio criado à lista estudios
                        tipoUsuarios.Add(tipoUsuario);
                    }
                }
            }
            // Retorna a lista de funcionarios
            return tipoUsuarios;
        }
    }
}
