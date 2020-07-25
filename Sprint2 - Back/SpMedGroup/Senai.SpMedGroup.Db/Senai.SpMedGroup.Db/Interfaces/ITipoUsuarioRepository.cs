using Senai.SpMedGroup.Db.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WeabApi.Db.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos usuario
        /// </summary>
        /// <returns>Uma lista dos tipos usuario</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um tipo usuario pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza uma tipo usuario existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoUsuarioAtualizado"></param>
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo usuario
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
