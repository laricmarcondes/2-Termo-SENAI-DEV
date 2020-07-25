using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IEventoRepository
    {
        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns></returns>
        List<Evento> Listar();

        /// <summary>
        /// Busca um evento pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Evento BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto novoEvento que será cadastrado</param>
        void Cadastrar(Evento novoEvento);

        /// <summary>
        /// Atualiza um evento existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventoAtualizado"></param>
        void Atualizar(int id, Evento eventoAtualizado);

        /// <summary>
        /// Deleta um evento
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os eventos com as informações das presencas
        /// </summary>
        /// <returns>Uma lista de eventos com as presencas</returns>
        List<Evento> ListarComPresenca();
    }
}
