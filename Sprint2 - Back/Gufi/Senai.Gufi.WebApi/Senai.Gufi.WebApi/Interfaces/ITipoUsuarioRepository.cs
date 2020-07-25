using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos usuarios
        /// </summary>
        /// <returns></returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um tipo usuário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um tipo usuário
        /// </summary>
        /// <param name="novoTipoUsuario"></param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um tipo usuário existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoUsuarioAtualizado"></param>
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo usuário
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os tipos usuario com as informações dos usuarios
        /// </summary>
        /// <returns>Uma lista de tipos usuario com os usuarios</returns>
        List<TipoUsuario> ListarComUsuario();
    }
}
