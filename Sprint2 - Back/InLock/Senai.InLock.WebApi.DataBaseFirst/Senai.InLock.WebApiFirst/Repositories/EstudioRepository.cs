using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApiFirst.Domains;
using Senai.InLock.WebApiFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApiFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=DEV3\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        InLockContext ctx = new InLockContext();

        public List<Estudios> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public Estudios BuscarPorId(int id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            ctx.Estudios.Add(novoEstudio);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Estudios estudioAtualizado)
        {
            var estudioBuscado = BuscarPorId(id);

            if (estudioBuscado != null)
            {
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
                estudioBuscado.Jogos = estudioAtualizado.Jogos;
            }

            ctx.Estudios.Update(estudioBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Estudios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Estudios> ListarPorJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
