using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SenaturContext ctx = new SenaturContext();

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuarios> Listar()
        {
            // Retorna uma lista com todas as informações dos usuários
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        /// <summary>
        /// Busca um usuário pelo e-mail e pela senha
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Senha"></param>
        /// <returns> O usuário buscado</returns>
        public Usuarios BuscarPorEmailSenha(string Email, string Senha)
        {
            // Busca um usuário pelo e-mail e pela senha informados
            Usuarios usuarioLogado = ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);

            //Retorna o usuário buscado pelos parâmetros desejados
            return usuarioLogado;
        }
    }
}
