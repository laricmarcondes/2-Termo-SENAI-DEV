using System.Collections.Generic;
using System.Linq;
using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;

namespace Senai.Senatur.WebApi.DatabaseFirst.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SenaturContext ctx = new SenaturContext();

        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Uma lista de pacotes</returns>
        public List<Pacotes> Listar()
        {
            // Retorna uma lista com todas as informações dos pacotes
            return ctx.Pacotes.ToList();
        }

        /// <summary>
        /// Atualiza um pacote existente
        /// </summary>
        /// <param name="id">ID do pacote que será atualizado</param>
        /// <param name="pacoteAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            // Busca um pacote através do id
            Pacotes pacoteBuscado = BuscarPorId(id);

            // Atribui os novos valores ao campos existentes
            pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            pacoteBuscado.Valor = pacoteAtualizado.Valor;
            pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;

            // Atualiza o pacote que foi buscado
            ctx.Pacotes.Update(pacoteBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();

        }

        /// <summary>
        /// Busca um pacote através do ID
        /// </summary>
        /// <param name="id">ID do pacote que será buscado</param>
        /// <returns>Um pacote buscado</returns>
        public Pacotes BuscarPorId(int id)
        {
            // Retorna o primeiro pacote encontrado para o ID informado
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="novoPacote">Objeto com as informações de cadastro</param>
        public void Cadastrar(Pacotes novoPacote)
        {
            // Adiciona este novoPacote
            ctx.Pacotes.Add(novoPacote);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um pacote existente
        /// </summary>
        /// <param name="id">ID do pacote que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o pacote que foi buscado
            ctx.Pacotes.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista os pacotes ativos e não ativos
        /// </summary>
        /// <param name="pacotesAtivos"></param>
        /// <returns>Uma lista dos pacotes desejados</returns>
        public List<Pacotes> PacotesAtivos(bool pacotesAtivos)
        {
            //Verifica se 'pacotesAtivos' é igual a 'true'
            if (pacotesAtivos == true)
            {
                //Caso seja, retornará os pacotes ativos
                return ctx.Pacotes.Where(p => p.Ativo == "Sim").ToList();
            }

            //Caso não seja, retornará os pacotes não ativos
            return ctx.Pacotes.Where(p => p.Ativo == "Não").ToList();
        }

        /// <summary>
        /// Lista os pacotes buscados por uma cidade
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Uma lista dos pacotes buscados pela cidade</returns>
        public List<Pacotes> ListarPorCidade(string cidade)
        {
            // Retorna uma lista com os pacotes buscados pela cidade desejada
            return ctx.Pacotes.Where(p => p.NomeCidade.Contains(cidade)).ToList();
        }

        /// <summary>
        /// Lista os pacotes um uma ordem
        /// </summary>
        /// <param name="ordem"></param>
        /// <returns>Uma lista com os pacotes na ordem desejada</returns>
        public List<Pacotes> ListarOrdenado(string ordem)
        {
            // Verifica se 'ordem' é igual a 'ASC'
            if (ordem == "ASC")
            {
                // Caso seja, retorna em ordem 'ASC'
                return ctx.Pacotes.OrderBy(p => p.Valor).ToList();
            }

            // Caso não seja, retorna em ordem 'DESC'
            return ctx.Pacotes.OrderByDescending(p => p.Valor).ToList();
        }
    }
}
