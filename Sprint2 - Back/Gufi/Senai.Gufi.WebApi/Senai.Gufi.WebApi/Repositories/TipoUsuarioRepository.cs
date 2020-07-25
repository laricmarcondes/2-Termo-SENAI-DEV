using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Lista todos os tipos usuario
        /// </summary>
        /// <returns>Uma lista de tipos usuario</returns>
        public List<TipoUsuario> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos usuario
            return ctx.TipoUsuario.ToList();
        }

        /// <summary>
        /// Busca um tipo usuario através do ID
        /// </summary>
        /// <param name="id">ID do tipo usuario que será buscado</param>
        /// <returns>Um tipo usuario buscado</returns>
        public TipoUsuario BuscarPorId(int id)
        {
            // Retorna o primeiro tipo usuario encontrado para o ID informado
            return ctx.TipoUsuario.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo tipo usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto com as informações de tipo usuario</param>
        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            // Adiciona este novoTipoUsuario
            ctx.TipoUsuario.Add(novoTipoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza um tipo usuario existente
        /// </summary>
        /// <param name="id">>ID do tipo usuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">>ID do tipo usuario que será atualizado</param>
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            // Busca um tipo usuario através do id
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            // Atribui o novo valor ao campo existente
            tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;

            // Atualiza o tipo usuario que foi buscado
            ctx.TipoUsuario.Update(tipoUsuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo usuario existente
        /// </summary>
        /// <param name="id">ID do tipo usuario que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o tipo evento através do id
            ctx.TipoUsuario.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos usuario com os usuarios
        /// </summary>
        /// <returns>Uma lista de tipos usuario com os usuarios</returns>
        public List<TipoUsuario> ListarComUsuario()
        {
            // Retorna uma lista com todas as informações dos tipos usuario e usuarios
            return ctx.TipoUsuario.Include(e => e.Usuario).ToList();
            // return ctx.TipoUsuario.Include("Usuario").ToList();
        }
    }
}
