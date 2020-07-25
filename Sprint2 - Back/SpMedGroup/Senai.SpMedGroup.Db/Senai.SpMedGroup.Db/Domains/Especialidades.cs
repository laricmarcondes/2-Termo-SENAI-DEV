using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Db.Domains
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            Medico = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome da especialidade é obrigatório")]
        public string NomeEspecialidade { get; set; }

        public ICollection<Medico> Medico { get; set; }
    }
}
