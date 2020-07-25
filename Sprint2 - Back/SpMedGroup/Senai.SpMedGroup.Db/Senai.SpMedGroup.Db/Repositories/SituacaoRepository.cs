using Senai.SpMedGroup.Db.Domains;
using Senai.SpMedGroup.WeabApi.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Lista todas as situacoes
        /// </summary>
        /// <returns>Uma lista das situacoes</returns>
        public List<Situacao> Listar()
        {
            // Retorna uma lista com todas as informações das situacoes
            return ctx.Situacao.ToList();
        }

        /// <summary>
        /// Busca uma situacao através do ID
        /// </summary>
        /// <param name="id">ID da situacao que será buscada</param>
        /// <returns>Uma situacao buscada</returns>
        public Situacao BuscarPorId(int id)
        {
            // Retorna a primeira situacao encontrada para o ID informado
            return ctx.Situacao.FirstOrDefault(c => c.IdSituacao == id);
        }

        /// <summary>
        /// Cadastra uma nova situacao
        /// </summary>
        /// <param name="novaSituacao">Objeto com as informações de situacao</param>
        public void Cadastrar(Situacao novaSituacao)
        {
            // Adiciona novaSituacao
            ctx.Situacao.Add(novaSituacao);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma situacao existente
        /// </summary>
        /// <param name="id">ID da situacao que será atualizada</param>
        /// <param name="situacaoAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Situacao situacaoAtualizada)
        {
            // Busca uma situacao através do id
            Situacao situacaoBuscada = ctx.Situacao.Find(id);

            // Atribui os novos valores ao campos existentes
            situacaoBuscada.Titulo = situacaoAtualizada.Titulo;

            // Atualiza a situacao que foi buscada
            ctx.Situacao.Update(situacaoBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma situacao existente
        /// </summary>
        /// <param name="id">ID da situacao que será deletada</param>
        public void Deletar(int id)
        {
            // Remove a situacao através do id
            ctx.Situacao.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}
