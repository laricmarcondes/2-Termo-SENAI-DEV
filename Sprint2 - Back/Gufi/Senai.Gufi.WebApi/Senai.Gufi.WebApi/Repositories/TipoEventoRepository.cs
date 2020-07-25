using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Lista todos os tipos evento
        /// </summary>
        /// <returns>Uma lista de tipos evento</returns>
        public List<TipoEvento> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos evento
            return ctx.TipoEvento.ToList();
        }

        /// <summary>
        /// Busca um tipo evento através do ID
        /// </summary>
        /// <param name="id">ID do tipo evento que será buscado</param>
        /// <returns>Um tipo evento buscado</returns>
        public TipoEvento BuscarPorId(int id)
        {
            // Retorna o primeiro tipo evento encontrado para o ID informado
            return ctx.TipoEvento.FirstOrDefault(te => te.IdTipoEvento == id);
        }

        /// <summary>
        /// Cadastra um novo tipo evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto com as informações de tipo evento</param>
        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            // Adiciona este novoTipoEvento
            ctx.TipoEvento.Add(novoTipoEvento);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza um tipo evento existente
        /// </summary>
        /// <param name="id">>ID do tipo evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">>ID do tipo evento que será atualizado</param>
        public void Atualizar(int id, TipoEvento tipoEventoAtualizado)
        {
            // Busca um tipo evento através do id
            TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

            // Atribui o novo valor ao campo existente
            tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;

            // Atualiza o tipo evento que foi buscado
            ctx.TipoEvento.Update(tipoEventoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo evento existente
        /// </summary>
        /// <param name="id">ID do tipo evento que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o tipo evento através do id
            ctx.TipoEvento.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos evento com os eventos
        /// </summary>
        /// <returns>Uma lista de tipos evento com os eventos</returns>
        public List<TipoEvento> ListarComEvento()
        {
            // Retorna uma lista com todas as informações dos tipos evento e eventos
            return ctx.TipoEvento.Include(e => e.Evento).ToList();
            // return ctx.TipoEvento.Include("Evento").ToList();
        }
    }
}
