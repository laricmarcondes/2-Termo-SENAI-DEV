using Senai.SpMedGroup.Db.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Interfaces
{
    interface IEnderecoClinicaRepository
    {
        /// <summary>
        /// Lista todos os endereços das clinicas
        /// </summary>
        /// <returns>Uma lista dos endereços das clinicas</returns>
        List<EnderecoClinica> Listar();

        /// <summary>
        /// Busca um endereço de clinica pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EnderecoClinica BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo endereço de clinica
        /// </summary>
        /// <param name="novoEnderecoClinica">Objeto novoEnderecoClinica que será cadastrado</param>
        void Cadastrar(EnderecoClinica novoEnderecoClinica);

        /// <summary>
        /// Atualiza uma endereco de clinica existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enderecoClinicaAtualizado"></param>
        void Atualizar(int id, EnderecoClinica enderecoClinicaAtualizado);

        /// <summary>
        /// Deleta um endereco de clinica
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
