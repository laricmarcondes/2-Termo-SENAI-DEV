using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Db.Domains
{
    public partial class Prontuario
    {
        public Prontuario()
        {
            Consulta = new HashSet<Consulta>();
            EnderecoProntuario = new HashSet<EnderecoProntuario>();
        }

        public int IdProntuario { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do paciente é obrigatório")]
        public string Nome { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O rg do paciente é obrigatório")]
        public string Rg { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O cpf do paciente é obrigatório")]
        public string Cpf { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data de nascimento do paciente é obrigatória")]
        public DateTime DataNascimento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O telefone do paciente é obrigatório")]
        public string Telefone { get; set; }

        public int? IdUsuario { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
        public ICollection<EnderecoProntuario> EnderecoProntuario { get; set; }
    }
}
