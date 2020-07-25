using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        // Define que o email do usuário precisa ser informado
        [Required(ErrorMessage = "O Email do usuário é obrigatório!")]
        public string Email { get; set; }

        public string Senha { get; set; }

        public int IdTipoUsuario { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }

        internal static UsuarioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
