using Senai.SpMedGroup.Db.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Interfaces
{
    interface ISituacaoRepository
    {
        /// <summary>
        /// Lista todas as situacoes
        /// </summary>
        /// <returns>Uma lista das situacoes</returns>
        List<Situacao> Listar();

        /// <summary>
        /// Busca uma siatuacao pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Situacao BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova situacao
        /// </summary>
        /// <param name="novaSituacao">Objeto novaSituacao que será cadastrado</param>
        void Cadastrar(Situacao novaSituacao);

        /// <summary>
        /// Atualiza uma situacao existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="situacaoAtualizada"></param>
        void Atualizar(int id, Situacao situacaoAtualizada);

        /// <summary>
        /// Deleta uma situacao
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
