using senai.Filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.webapi.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> Listar();

        void Cadastrar(FilmeDomain filme);

        void AtualizarIdCorpo(FilmeDomain filme);

        void AtualizarUrl(int id, FilmeDomain filme);

        void Deletar(int id);

        FilmeDomain BuscarPorId(int id);

        void AtualizarIdUrl(int id, FilmeDomain filmeAtualizado);
        object BuscarPorTitulo(string busca);
    }
}
