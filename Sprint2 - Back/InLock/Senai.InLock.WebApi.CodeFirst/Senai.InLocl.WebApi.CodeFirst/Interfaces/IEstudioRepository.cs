using Senai.InLocl.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudios> Listar();

        Estudios BuscarPorId(int id);

        void Cadastrar(Estudios novoEstudio);

        void Atualizar(int id, Estudios estudioAtualizado);

        void Deletar(int id);

        List<Estudios> ListarPorJogos();

    }
}
