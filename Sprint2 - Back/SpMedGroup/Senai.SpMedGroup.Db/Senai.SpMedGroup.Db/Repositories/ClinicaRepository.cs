using Senai.SpMedGroup.Db.Domains;
using Senai.SpMedGroup.WeabApi.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Uma lista das clinicas</returns>
        public List<Clinica> Listar()
        {
            // Retorna uma lista com todas as informações das clinicas
            return ctx.Clinica.ToList();
        }

        /// <summary>
        /// Busca uma clinica através do ID
        /// </summary>
        /// <param name="id">ID da clinica que será buscada</param>
        /// <returns>Uma clinica buscada</returns>
        public Clinica BuscarPorId(int id)
        {
            // Retorna a primeira clinica encontrada para o ID informado
            return ctx.Clinica.FirstOrDefault(c => c.IdClinica == id);
        }

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">Objeto com as informações de clinica</param>
        public void Cadastrar(Clinica novaClinica)
        {
            // Adiciona novaClinica
            ctx.Clinica.Add(novaClinica);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="id">ID da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            // Busca uma clinica através do id
            Clinica clinicaBuscada = ctx.Clinica.Find(id);

            // Atribui os novos valores ao campos existentes
            clinicaBuscada.NomeClinica = clinicaAtualizada.NomeClinica;
            clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;

            // Atualiza a clinica que foi buscada
            ctx.Clinica.Update(clinicaBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma clinica existente
        /// </summary>
        /// <param name="id">ID da clinica que será deletada</param>
        public void Deletar(int id)
        {
            // Remove a clinica através do id
            ctx.Clinica.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}
