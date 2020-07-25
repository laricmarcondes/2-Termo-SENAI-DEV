using Senai.SpMedGroup.Db.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Interfaces
{
    interface IProntuarioRepository
    {
        /// <summary>
        /// Lista todos os prontuarios
        /// </summary>
        /// <returns>Uma lista dos prontuarios</returns>
        List<Prontuario> Listar();

        /// <summary>
        /// Busca um prontuario pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Prontuario BuscarPorId(int id);

        /// <summary>
        /// Lista todos as consultas que um determinado paciente possui
        /// </summary>
        /// <param name="id">ID do paciente que participa das consultas</param>
        /// <returns>Uma lista de consultas com os dados</returns>
        List<Prontuario> ListarMinhasConsultas(int id);

        /// <summary>
        /// Cadastra um novo prontuario
        /// </summary>
        /// <param name="novoProntuario">Objeto novoProntuario que será cadastrado</param>
        void Cadastrar(Prontuario novoProntuario);

        /// <summary>
        /// Atualiza uma prontuario existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prontuarioAtualizado"></param>
        void Atualizar(int id, Prontuario prontuarioAtualizado);

        /// <summary>
        /// Deleta um prontuario
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
