using Senai.SpMedGroup.Db.Domains;
using Senai.SpMedGroup.WeabApi.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Repositories
{
    public class EnderecoClinicaRepository : IEnderecoClinicaRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Lista todos os enderecos das clinicas
        /// </summary>
        /// <returns>Uma lista dos enderecos das clinicas</returns>
        public List<EnderecoClinica> Listar()
        {
            // Retorna uma lista com todas as informações dos enderecos das clinicas
            return ctx.EnderecoClinica.ToList();
        }

        /// <summary>
        /// Busca o endereco de uma clinica através do ID
        /// </summary>
        /// <param name="id">ID do endereco da clinica que será buscada</param>
        /// <returns>Um endereço da clinica buscada</returns>
        public EnderecoClinica BuscarPorId(int id)
        {
            // Retorna o primeiro endereco da clinica encontrada para o ID informado
            return ctx.EnderecoClinica.FirstOrDefault(c => c.IdEnderecoClinica == id);
        }

        /// <summary>
        /// Cadastra um novo endereco clinica
        /// </summary>
        /// <param name="novoEnderecoClinica">Objeto com as informações de endereco clinica</param>
        public void Cadastrar(EnderecoClinica novoEnderecoClinica)
        {
            // Adiciona novEnderecoClinica
            ctx.EnderecoClinica.Add(novoEnderecoClinica);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza um endereco de clinica existente
        /// </summary>
        /// <param name="id">ID de endereco  clinica que será atualizado</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, EnderecoClinica enderecoClinicaAtualizado)
        {
            // Busca um endereco de clinica através do id
            EnderecoClinica enderecoclinicaBuscado = ctx.EnderecoClinica.Find(id);

            // Atribui os novos valores ao campos existentes
            enderecoclinicaBuscado.NomeEndereC = enderecoClinicaAtualizado.NomeEndereC;
            enderecoclinicaBuscado.Numero = enderecoClinicaAtualizado.Numero;
            enderecoclinicaBuscado.Cidade = enderecoClinicaAtualizado.Cidade;
            enderecoclinicaBuscado.Estado = enderecoClinicaAtualizado.Estado;
            enderecoclinicaBuscado.IdClinica = enderecoClinicaAtualizado.IdClinica;

            // Atualiza o endereco da clinica que foi buscado
            ctx.EnderecoClinica.Update(enderecoclinicaBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um endereco de clinica existente
        /// </summary>
        /// <param name="id">ID do endereco da clinica que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o endereco da clinica através do id
            ctx.EnderecoClinica.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}
