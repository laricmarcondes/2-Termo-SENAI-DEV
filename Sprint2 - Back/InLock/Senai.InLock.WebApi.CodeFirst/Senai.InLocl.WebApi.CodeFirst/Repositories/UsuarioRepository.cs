using Senai.InLock.WebApi.CodeFirst.Interfaces;
using Senai.InLocl.WebApi.CodeFirst.Contexts;
using Senai.InLocl.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV3\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132";

        InLockContext ctx = new InLockContext();

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuarios BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Usuarios usuarioAtualizado)
        {
            ctx.Usuarios.Update(BuscarPorId(id));
            ctx.Usuarios.Update(usuarioAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }
    }
}
