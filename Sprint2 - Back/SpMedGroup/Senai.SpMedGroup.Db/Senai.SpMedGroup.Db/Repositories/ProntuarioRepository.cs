using Microsoft.EntityFrameworkCore;
using Senai.SpMedGroup.Db.Domains;
using Senai.SpMedGroup.WeabApi.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Lista todos os prontuarios
        /// </summary>
        /// <returns>Uma lista dos prontuarios</returns>
        public List<Prontuario> Listar()
        {
            // Retorna uma lista com todas as informações dos prontuarios
            return ctx.Prontuario.ToList();
        }

        /// <summary>
        /// Busca um prontuario através do ID
        /// </summary>
        /// <param name="id">ID do prontuario que será buscado</param>
        /// <returns>Uma prontuario buscado</returns>
        public Prontuario BuscarPorId(int id)
        {
            // Retorna o primeiro prontuario encontrado para o ID informado
            return ctx.Prontuario.FirstOrDefault(p => p.IdProntuario == id);
        }

        /// <summary>
        /// Busca as consultas do usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma lista das consultas do usuario</returns>
        public List<Prontuario> ListarMinhasConsultas(int id)
        {
            // Retorna uma lista com todas as informações das consultas
            return ctx.Prontuario
                // Adiciona na busca as informações da consulta
                .Include(p => p.Consulta)
                // Estabelece como parâmetro de consulta o ID do prontuario recebido
                .Where(p => p.IdUsuario == id)
                .ToList();
        }

        /// <summary>
        /// Cadastra um novo prontuario
        /// </summary>
        /// <param name="novoProntuario">Objeto com as informações de prontuarios</param>
        public void Cadastrar(Prontuario novoProntuario)
        {
            // Adiciona novoProntuario
            ctx.Prontuario.Add(novoProntuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza um prontuario existente
        /// </summary>
        /// <param name="id">ID do prontuario que será atualizado</param>
        /// <param name="prontuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Prontuario prontuarioAtualizado)
        {
            // Busca um medico através do id
            Prontuario prontuarioBuscado = ctx.Prontuario.Find(id);

            // Atribui os novos valores ao campos existentes
            prontuarioBuscado.Nome = prontuarioAtualizado.Nome;
            prontuarioBuscado.Rg = prontuarioAtualizado.Rg;
            prontuarioBuscado.Cpf = prontuarioAtualizado.Cpf;
            prontuarioBuscado.DataNascimento = prontuarioAtualizado.DataNascimento;
            prontuarioBuscado.Telefone = prontuarioAtualizado.Telefone;
            prontuarioBuscado.IdUsuario = prontuarioAtualizado.IdUsuario;


            // Atualiza o medico que foi buscado
            ctx.Prontuario.Update(prontuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um prontuario existente
        /// </summary>
        /// <param name="id">ID do prontuario que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o prontuario através do id
            ctx.Prontuario.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}
