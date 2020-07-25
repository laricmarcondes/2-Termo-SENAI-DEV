using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.DatabaseFirst.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 30 caracteres.")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        public int? IdTipoUsuario { get; set; }

        public TiposUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
