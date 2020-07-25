using Microsoft.EntityFrameworkCore;
using Senai.SpMedGroup.Db.Domains;
using Senai.SpMedGroup.WeabApi.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Lista todas os medicos
        /// </summary>
        /// <returns>Uma lista dos medicos</returns>
        public List<Medico> Listar()
        {
            // Retorna uma lista com todas as informações dos medicos
            return ctx.Medico.ToList();
        }

        /// <summary>
        /// Busca um medico através do ID
        /// </summary>
        /// <param name="id">ID do medico que será buscado</param>
        /// <returns>Um medico buscado</returns>
        public Medico BuscarPorId(int id)
        {
            // Retorna o primeiro medico encontrado para o ID informado
            return ctx.Medico.FirstOrDefault(m => m.IdMedico == id);
        }


        /// <summary>
        /// Busca as consultas do usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma lista das consultas do usuario</returns>
        public List<Medico> ListarMinhasConsultas(int id)
        {
            // Retorna uma lista com todas as informações das consultas
            return ctx.Medico
                // Adiciona na busca as informações da consulta
                .Include(m => m.Consulta)
                // Estabelece como parâmetro de consulta o ID do medico recebido
                .Where(c => c.IdUsuario == id)
                .ToList();
        }

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">Objeto com as informações de medicos</param>
        public void Cadastrar(Medico novoMedico)
        {
            // Adiciona novoMedico
            ctx.Medico.Add(novoMedico);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza um medico existente
        /// </summary>
        /// <param name="id">ID do medico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Medico medicoAtualizado)
        {
            // Busca um medico através do id
            Medico medicoBuscado = ctx.Medico.Find(id);

            // Atribui os novos valores ao campos existentes
            medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
            medicoBuscado.Crm = medicoAtualizado.Crm;
            medicoBuscado.IdClinica = medicoAtualizado.IdClinica;
            medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
            medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;


            // Atualiza o medico que foi buscado
            ctx.Medico.Update(medicoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um medico existente
        /// </summary>
        /// <param name="id">ID do medico que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o medico através do id
            ctx.Medico.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}
