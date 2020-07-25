using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface ITipoEventoRepository
    {
        /// <summary>
        /// Lista Todos os tipos de eventos
        /// </summary>
        /// <returns></returns>
        List<TipoEvento> Listar();

        /// <summary>
        /// Busca um tipo de evento por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TipoEvento BuscarPorId(int id);

        /// <summary>
        /// Cadastra um tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento"></param>
        void Cadastrar(TipoEvento novoTipoEvento);

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoEventoAtualizado"></param>
        void Atualizar(int id, TipoEvento tipoEventoAtualizado);

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os tipos evento com as informações dos eventos
        /// </summary>
        /// <returns>Uma lista de tipos evento com os eventos</returns>
        List<TipoEvento> ListarComEvento();
    }
}
