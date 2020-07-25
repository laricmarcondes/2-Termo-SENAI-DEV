using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Controllers;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Usuario> Listar()
        {
            // Retorna uma lista com todas as informações dos usuarios
            return ctx.Usuario.ToList();
        }

        /// <summary>
        /// Busca um usuario através do ID
        /// </summary>
        /// <param name="id">ID do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        public Usuario BuscarPorId(int id)
        {
            // Retorna o primeiro usuario encontrado para o ID informado
            return ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações de usuario</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona este novoUsuario
            ctx.Usuario.Add(novoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            // Busca um usuario através do id
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Atribui os novos valores ao campos existentes
            usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;
            usuarioBuscado.Genero = usuarioAtualizado.Genero;
            usuarioBuscado.DataNascimento = usuarioAtualizado.DataNascimento;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

            // Atualiza o usuario que foi buscado
            ctx.Usuario.Update(usuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o usuario através do id
            ctx.Usuario.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuario pelo email e senha
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Senha"></param>
        /// <returns>O usuarrio buscado</returns>
        public Usuario BuscarPorEmailSenha(string Email, string Senha)
        {
            // Busca um usuário pelo e-mail e pela senha informados
            Usuario usuarioLogado = ctx.Usuario.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);

            //Retorna o usuário buscado pelos parâmetros desejados
            return usuarioLogado;
        }

        public List<Usuario> ListarComTipoUsuario()
        {
            // Retorna uma lista com todas as informações dos usuarios e tipos usuario
            return ctx.Usuario.Include(p => p.IdTipoUsuarioNavigation).ToList();
            // return ctx.Usuario.Include("IdTipoUsuarioNavigation").ToList();
        }

        public List<Usuario> ListarComPresenca()
        {
            // Retorna uma lista com todas as informações dos usuarios e presencas
            return ctx.Usuario.Include(p => p.Presenca).ToList();
            // return ctx.Usuario.Include("Presenca").ToList();
        }
    }
}
