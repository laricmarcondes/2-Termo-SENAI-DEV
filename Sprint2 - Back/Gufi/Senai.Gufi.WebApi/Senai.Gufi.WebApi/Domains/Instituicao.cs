using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Evento = new HashSet<Evento>();
        }

        public int IdInstituicao { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O cnpj da instituição é obrigatório!")]
        public string Cnpj { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do da instituição é obrigatório!")]
        public string NomeFantasia { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O endereço da instituição é obrigatório!")]
        public string Endereco { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
}
