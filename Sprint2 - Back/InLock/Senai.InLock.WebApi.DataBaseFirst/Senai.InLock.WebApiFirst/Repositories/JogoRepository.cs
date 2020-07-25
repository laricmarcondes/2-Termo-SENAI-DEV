using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApiFirst.Domains;
using Senai.InLock.WebApiFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApiFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=DEV3\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        InLockContext ctx = new InLockContext();

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Jogos jogoAtualizado)
        {
            var jogoBuscado = BuscarPorId(id);

            if(jogoBuscado != null)
            {
                jogoBuscado.NomeJogo = jogoAtualizado.NomeJogo;
                jogoBuscado.Descricao = jogoAtualizado.Descricao;
                jogoBuscado.DataLancamento = jogoAtualizado.DataLancamento;
                jogoBuscado.Valor = jogoAtualizado.Valor;
                jogoBuscado.IdEstudio = jogoAtualizado.IdEstudio;
            }

            ctx.Jogos.Update(jogoBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Jogos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Jogos> ListarComEstudio()
        {
            return ctx.Jogos.Include(e => e.IdEstudioNavigation).ToList();
        }

        public List<Jogos> ListarPorEstudio(int id)
        {
            return ctx.Jogos.ToList().FindAll(j => j.IdEstudio == id);
        }
    }
}
