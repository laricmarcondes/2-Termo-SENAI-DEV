using Senai.SpMedGroup.Db.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Lista todas as especialidades
        /// </summary>
        /// <returns>Uma lista das especialidades</returns>
        List<Especialidades> Listar();

        /// <summary>
        /// Busca uma especialidades pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Especialidades BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova especialidades
        /// </summary>
        /// <param name="novaEspecialidade">Objeto novaEspecialidade que será cadastrada</param>
        void Cadastrar(Especialidades novaEspecialidade);

        /// <summary>
        /// Atualiza uma especialidade existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="especialidadeAtualizada"></param>
        void Atualizar(int id, Especialidades especialidadeAtualizada);

        /// <summary>
        /// Deleta uma especialidade
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
