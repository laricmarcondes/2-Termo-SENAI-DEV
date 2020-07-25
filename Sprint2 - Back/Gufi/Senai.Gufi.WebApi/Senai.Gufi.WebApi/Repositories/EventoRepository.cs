using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Uma lista de eventos</returns>
        public List<Evento> Listar()
        {
            // Retorna uma lista com todas as informações dos eventos
            return ctx.Evento.ToList();
        }

        /// <summary>
        /// Busca um evento através do ID
        /// </summary>
        /// <param name="id">ID do evento que será buscado</param>
        /// <returns>Um evento buscado</returns>
        public Evento BuscarPorId(int id)
        {
            // Retorna o primeiro evento encontrado para o ID informado
            return ctx.Evento.FirstOrDefault(e => e.IdEvento == id);
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto com as informações de evento</param>
        public void Cadastrar(Evento novoEvento)
        {
            // Adiciona este novoEvento
            ctx.Evento.Add(novoEvento);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <param name="eventoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Evento eventoAtualizado)
        {
            // Busca um evento através do id
            Evento eventoBuscado = ctx.Evento.Find(id);

            // Atribui os novos valores ao campos existentes
            eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
            eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
            eventoBuscado.Descricao = eventoAtualizado.Descricao;
            eventoBuscado.AcessoLivre = eventoAtualizado.AcessoLivre;
            eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
            eventoBuscado.IdInstituicao = eventoAtualizado.IdInstituicao;
            eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;

            // Atualiza o evento que foi buscado
            ctx.Evento.Update(eventoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o evento através do id
            ctx.Evento.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Evento> ListarComPresenca()
        {
            // Retorna uma lista com todas as informações dos eventos e presencas
            return ctx.Evento.Include(p => p.Presenca).ToList();
            // return ctx.Evento.Include("Presenca").ToList();
        }
    }
}
