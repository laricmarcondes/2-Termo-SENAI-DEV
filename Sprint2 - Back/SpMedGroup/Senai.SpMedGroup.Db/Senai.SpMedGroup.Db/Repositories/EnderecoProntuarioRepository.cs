using Senai.SpMedGroup.Db.Domains;
using Senai.SpMedGroup.WeabApi.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Repositories
{
    public class EnderecoProntuarioRepository : IEnderecoProntuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Lista todos os enderecos dos prontuarios
        /// </summary>
        /// <returns>Uma lista dos enderecos dos prontuarios</returns>
        public List<EnderecoProntuario> Listar()
        {
            // Retorna uma lista com todas as informações dos enderecos dos prontuarios
            return ctx.EnderecoProntuario.ToList();
        }

        /// <summary>
        /// Busca o endereco de um prontuario através do ID
        /// </summary>
        /// <param name="id">ID do endereco do prontuario que será buscado</param>
        /// <returns>Um endereço do prontuario buscado</returns>
        public EnderecoProntuario BuscarPorId(int id)
        {
            // Retorna o primeiro endereco do prontuario encontrado para o ID informado
            return ctx.EnderecoProntuario.FirstOrDefault(c => c.IdEnderecoProntuario == id);
        }

        /// <summary>
        /// Cadastra um novo endereco prontuario
        /// </summary>
        /// <param name="novoEnderecoProntuario">Objeto com as informações de endereco prontuario</param>
        public void Cadastrar(EnderecoProntuario novoEnderecoProntuario)
        {
            // Adiciona novoEnderecoClinica
            ctx.EnderecoProntuario.Add(novoEnderecoProntuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma endereco de prontuario existente
        /// </summary>
        /// <param name="id">ID do endereco do prontuario que será atualizado</param>
        /// <param name="enderecoProntuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, EnderecoProntuario enderecoProntuarioAtualizado)
        {
            // Busca um endereco de prontuario através do id
            EnderecoProntuario enderecoProntuarioBuscado = ctx.EnderecoProntuario.Find(id);

            // Atribui os novos valores ao campos existentes
            enderecoProntuarioBuscado.NomeEnderecoP = enderecoProntuarioAtualizado.NomeEnderecoP;
            enderecoProntuarioBuscado.Numero = enderecoProntuarioAtualizado.Numero;
            enderecoProntuarioBuscado.Bairro = enderecoProntuarioAtualizado.Bairro;
            enderecoProntuarioBuscado.Cidade = enderecoProntuarioAtualizado.Cidade;
            enderecoProntuarioBuscado.Estado = enderecoProntuarioAtualizado.Estado;
            enderecoProntuarioBuscado.Cep = enderecoProntuarioAtualizado.Cep;
            enderecoProntuarioBuscado.IdProntuario = enderecoProntuarioAtualizado.IdProntuario;

            // Atualiza o endereco da clinica que foi buscado
            ctx.EnderecoProntuario.Update(enderecoProntuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um endereco de prontuario existente
        /// </summary>
        /// <param name="id">ID do endereco do prontuario que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o endereco do prontuario através do id
            ctx.EnderecoProntuario.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}
