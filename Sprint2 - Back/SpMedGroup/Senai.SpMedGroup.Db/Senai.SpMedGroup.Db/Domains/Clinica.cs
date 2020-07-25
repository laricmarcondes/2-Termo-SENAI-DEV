using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Db.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            EnderecoClinica = new HashSet<EnderecoClinica>();
            Medico = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome da clínica é obrigatória")]
        public string NomeClinica { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A razão social da clínica é obrigatória")]
        public string RazaoSocial { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O cnpj da clínica é obrigatória")]
        public string Cnpj { get; set; }

        public ICollection<EnderecoClinica> EnderecoClinica { get; set; }
        public ICollection<Medico> Medico { get; set; }
    }
}
