using Senai.SpMedGroup.Db.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Interfaces
{
    interface IEnderecoProntuarioRepository
    {
        /// <summary>
        /// Lista todos os endereços dos prontuarios
        /// </summary>
        /// <returns>Uma lista dos endereços dos prontuarios</returns>
        List<EnderecoProntuario> Listar();

        /// <summary>
        /// Busca um endereço de prontuario pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EnderecoProntuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo endereço de prontuario
        /// </summary>
        /// <param name="novoEnderecoProntuario">Objeto novoEnderecoProntuario que será cadastrado</param>
        void Cadastrar(EnderecoProntuario novoEnderecoProntuario);

        /// <summary>
        /// Atualiza uma endereco de prontuario existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enderecoProntuarioAtualizado"></param>
        void Atualizar(int id, EnderecoProntuario enderecoProntuarioAtualizado);

        /// <summary>
        /// Deleta um endereco de prontuario
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
