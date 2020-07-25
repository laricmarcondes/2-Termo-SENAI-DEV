using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna uma lista dos jogos</returns>
        List<JogoDomain> Listar();

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        void Cadastrar(JogoDomain jogo);

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado que será atualizado</param>

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        void Deletar(int id);

        void AtualizarIdUrl(int id, JogoDomain funcionarioAtualizado);

        JogoDomain BuscarPorId(int idJogo);

        void AtualizarIdCorpo(JogoDomain jogoAtualizado);

        void Atualizar(int id, JogoDomain jogoAtualizado);
    }
}
