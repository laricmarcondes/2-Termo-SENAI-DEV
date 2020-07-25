using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O id do usuário é obrigatório!")]
        public int? IdUsuario { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O id do evento é obrigatório!")]
        public int? IdEvento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O situação do evento é obrigatória!")]
        public string Situacao { get; set; }

        public Evento IdEventoNavigation { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
    }
}
