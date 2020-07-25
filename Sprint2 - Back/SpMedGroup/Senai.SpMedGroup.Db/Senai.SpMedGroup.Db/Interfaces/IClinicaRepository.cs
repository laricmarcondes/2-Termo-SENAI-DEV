using Senai.SpMedGroup.Db.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Uma lista das clinicas</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Busca uma clinica pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Clinica BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica que será cadastrada</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinicaAtualizada"></param>
        void Atualizar(int id, Clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma clinica
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
