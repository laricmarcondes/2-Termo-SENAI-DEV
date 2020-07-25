using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IPresencaRepository
    {
        /// <summary>
        /// Lista todas as presenças
        /// </summary>
        /// <returns></returns>
        List<Presenca> Listar();

        /// <summary>
        /// Busca uma presença por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Presenca BuscarPorId(int id);

        /// <summary>
        /// Lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">ID do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        List<Presenca> ListarMinhas(int id);

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscrição</param>
        void Inscrever(Presenca inscricao);

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá a situação alterada</param>
        /// <param name="status">Parâmetro que atualiza o situação da presença para Confirmada, Não confirmada ou Recusada</param>
        void AprovarRecusar(int id, string status);

        /// <summary>
        /// Convida outro usuário para um evento
        /// </summary>
        /// <param name="convite">Objeto com as informações do convite</param>
        void Convidar(Presenca convite);

        /// <summary>
        /// Deleta uma presenca
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
