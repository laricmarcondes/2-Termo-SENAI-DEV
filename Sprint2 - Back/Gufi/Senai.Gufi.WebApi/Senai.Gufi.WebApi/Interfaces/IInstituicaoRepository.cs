using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        /// <summary>
        /// Lista todas as instituições
        /// </summary>
        /// <returns></returns>
        List<Instituicao> Listar();

        /// <summary>
        /// Busca uma instituição pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Instituicao BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="novaInstituicao"></param>
        void Cadastrar(Instituicao novaInstituicao);

        /// <summary>
        /// Atualiza uma instituição existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instituicaoAtualizada"></param>
        void Atualizar(int id, Instituicao instituicaoAtualizada);

        /// <summary>
        /// Deleta uma instituição
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
