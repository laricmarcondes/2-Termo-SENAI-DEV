using Senai.Gufi.WebApi.Controllers;
using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns></returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario"></param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAtualizado"></param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Delets um usuário
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

        /// <summary>
        /// Busca um usuário por email e senha
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Senha"></param>
        /// <returns></returns>
        Usuario BuscarPorEmailSenha(string Email, string Senha);

        /// <summary>
        /// Lista todos os usuarios com as informações dos tipos usuario
        /// </summary>
        /// <returns>Uma lista de usuarios com os tipos usuario</returns>
        List<Usuario> ListarComTipoUsuario();

        /// <summary>
        /// Lista todos os usuarios com as informações das presencas
        /// </summary>
        /// <returns>Uma lista de usuarios com as presencas</returns>
        List<Usuario> ListarComPresenca();
    }
}
