using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Db.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do médico é obrigatório")]
        public string NomeMedico { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O crm do médico é obrigatório")]
        public string Crm { get; set; }

        public int? IdClinica { get; set; }

        public int? IdEspecialidade { get; set; }

        public int? IdUsuario { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
        public Especialidades IdEspecialidadeNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
