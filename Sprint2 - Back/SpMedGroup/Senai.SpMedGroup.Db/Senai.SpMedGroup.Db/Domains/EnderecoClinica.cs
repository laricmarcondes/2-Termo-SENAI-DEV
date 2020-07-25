using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Db.Domains
{
    public partial class EnderecoClinica
    {
        public int IdEnderecoClinica { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome doenderço da clínica é obrigatório")]
        public string NomeEndereC { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O número do endereço da clínica é obrigatório")]
        public string Numero { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A cidade do endereço da clínica é obrigatória")]
        public string Cidade { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O estado do endereço da clínica é obrigatório")]
        public string Estado { get; set; }

        public int? IdClinica { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
    }
}
