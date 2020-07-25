using Senai.SpMedGroup.Db.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Uma lista das consultas</returns>
        List<Consulta> Listar();

        /// <summary>
        /// Busca uma consulta pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Consulta BuscarPorId(int id);

        List<Consulta> ListarConsultasCompletas(int id);

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta que será cadastrada</param>
        void Cadastrar(Consulta novaClinica);

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consultaAtualizada"></param>
        void Atualizar(int id, Consulta consultaAtualizada);

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
