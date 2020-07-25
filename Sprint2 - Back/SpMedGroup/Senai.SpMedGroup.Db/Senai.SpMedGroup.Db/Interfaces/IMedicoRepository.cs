using Senai.SpMedGroup.Db.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Uma lista dos medicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Busca um medico pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Medico BuscarPorId(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Medico> ListarMinhasConsultas(int id);

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico que será cadastrado</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Atualiza uma medico existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medicoAtualizado"></param>
        void Atualizar(int id, Medico medicoAtualizado);

        /// <summary>
        /// Deleta um medico
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
