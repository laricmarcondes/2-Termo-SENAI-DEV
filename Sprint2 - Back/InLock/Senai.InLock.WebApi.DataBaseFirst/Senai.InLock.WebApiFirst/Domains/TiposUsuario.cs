using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApiFirst.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoUsuario { get; set; }

        public string Tipo { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
