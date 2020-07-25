using Senai.InLock.WebApi.CodeFirst.Interfaces;
using Senai.InLocl.WebApi.CodeFirst.Contexts;
using Senai.InLocl.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV3\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        InLockContext ctx = new InLockContext();

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuario.ToList();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            ctx.TiposUsuario.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            ctx.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
            ctx.TiposUsuario.Update(tipoUsuarioAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TiposUsuario.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }
    }
}
