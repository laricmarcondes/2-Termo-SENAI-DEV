using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Lista todos as instituicoes
        /// </summary>
        /// <returns>Uma lista de instituicoes</returns>
        public List<Instituicao> Listar()
        {
            // Retorna uma lista com todas as informações das instituicoes
            return ctx.Instituicao.ToList();
        }

        /// <summary>
        /// Busca uma instituicao através do ID
        /// </summary>
        /// <param name="id">ID da instituicao que será buscada</param>
        /// <returns>Uma instituicao buscada</returns>
        public Instituicao BuscarPorId(int id)
        {
            // Retorna a primeira instituicao encontrada para o ID informado
            return ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id);
        }

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="novaInstituicao">Objeto com as informações de instituicao</param>
        public void Cadastrar(Instituicao novaInstituicao)
        {
            // Adiciona este novaInstituicao
            ctx.Instituicao.Add(novaInstituicao);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será atualizado</param>
        /// <param name="instituicaoAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Instituicao instituicaoAtualizada)
        {
            // Busca uma instituicao através do id
            Instituicao instituicaoBuscada = ctx.Instituicao.Find(id);

            // Atribui os novos valores ao campos existentes
            instituicaoBuscada.Cnpj = instituicaoAtualizada.Cnpj;
            instituicaoBuscada.NomeFantasia = instituicaoAtualizada.NomeFantasia;
            instituicaoBuscada.Endereco = instituicaoAtualizada.Endereco;

            // Atualiza a instituicao que foi buscada
            ctx.Instituicao.Update(instituicaoBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será deletada</param>
        public void Deletar(int id)
        {
            // Remove a instituicao através do id
            ctx.Instituicao.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}
