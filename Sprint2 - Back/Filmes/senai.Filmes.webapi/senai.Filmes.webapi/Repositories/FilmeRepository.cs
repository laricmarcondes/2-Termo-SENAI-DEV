using senai.Filmes.webapi.Domains;
using senai.Filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.webapi.Repositories
{
    public class FilmeRepository : IFilmeRepository

    {
        GeneroRepository _generoRepository = new GeneroRepository();

        private string stringConexao = "Data Source=DEV3\\SQLEXPRESS; initial catalog=Filmes_Tarde; user Id=sa; pwd=sa@132";
        
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Fimes SET Titulo = @Titulo WHERE IdFilme = @ID";
                
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Filmes SET Titulo = @Titulo WHERE IdFilme = @ID";
                
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdFilme, Titulo FROM Filmes WHERE IdFilme = @ID";
                
                con.Open();
                
                SqlDataReader rdr;
                
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    
                    rdr = cmd.ExecuteReader();
                    
                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        
                        return filme;
                    }
                    
                    return null;
                }
            }
        }
        
        public void Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Filmes(Titulo) VALUES (@Titulo)";
                
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                
                con.Open();
                
                cmd.ExecuteNonQuery();
            }
        }
        
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Filmes WHERE IdFilme = @ID";
                
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    
                    con.Open();
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();
            
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFilme, Titulo, Generos.IdGenero, Generos.Nome FROM Filmes " +
                                        "INNER JOIN Generos ON Filmes.IdGenero = Generos.IdGenero";
                
                con.Open();
                
                SqlDataReader rdr;
                
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            
                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Nome = rdr["Nome"].ToString()
                        };

                        filme.Genero = _generoRepository.BuscarPorId(filme.IdGenero);
                        
                        filmes.Add(filme);
                    }
                }
            }
          
            return filmes;
        }
    }
}
