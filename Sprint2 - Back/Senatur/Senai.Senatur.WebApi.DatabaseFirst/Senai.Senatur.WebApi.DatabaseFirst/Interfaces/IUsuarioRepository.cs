using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// listar todos os usuarios
        /// </summary>
        /// <returns>Uma lista dos usuarios</returns>
        List<Usuarios> Listar();

        /// <summary>
        /// Busca um usuário pelo e-mail e pela senha
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Senha"></param>
        /// <returns>O usuário buscado</returns>
        Usuarios BuscarPorEmailSenha(string Email, string Senha);
    }
}
