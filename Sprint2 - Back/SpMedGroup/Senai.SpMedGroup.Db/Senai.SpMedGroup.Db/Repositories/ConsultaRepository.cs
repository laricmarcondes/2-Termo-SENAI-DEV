using Microsoft.EntityFrameworkCore;
using Senai.SpMedGroup.Db.Domains;
using Senai.SpMedGroup.WeabApi.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Uma lista das consultas</returns>
        public List<Consulta> Listar()
        {
            // Retorna uma lista com todas as informações das consultas
            return ctx.Consulta.ToList();
        }

        /// <summary>
        /// Busca uma consulta através do ID
        /// </summary>
        /// <param name="id">ID da consulta que será buscada</param>
        /// <returns>Uma consulta buscada</returns>
        public Consulta BuscarPorId(int id)
        {
            // Retorna a primeira consulta encontrada para o ID informado
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id);
        }

        /// <summary>
        /// Busca as cosultas com informações completas
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma lista das consultas completas</returns>
        public List<Consulta> ListarConsultasCompletas(int id)
        {
            // Retorna uma lista com todas as informações das consultas
            return ctx.Consulta
                // Adiciona na busca as informações da situacao
                .Include(c => c.IdSituacaoNavigation)
                // Adiciona na busca as informações do medico
                .Include(c => c.IdMedicoNavigation)
                // Adiciona na busca as informações do prontuario
                .Include(c => c.IdProntuarioNavigation)
                .ToList();
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto com as informações de consulta</param>
        public void Cadastrar(Consulta novaConsulta)
        {
            // Adiciona novaConsulta
            ctx.Consulta.Add(novaConsulta);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            // Busca uma consulta através do id
            Consulta consultaBuscada = ctx.Consulta.Find(id);

            // Atribui os novos valores ao campos existentes
            consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;

            // Atualiza a consulta que foi buscada
            ctx.Consulta.Update(consultaBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma consulta existente
        /// </summary>
        /// <param name="id">ID da consulta que será deletada</param>
        public void Deletar(int id)
        {
            // Remove a consulta através do id
            ctx.Consulta.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}
