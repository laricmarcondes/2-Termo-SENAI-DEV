using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Db.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O título da situação é obrigatório")]
        public string Titulo { get; set; }

        public ICollection<Consulta> Consulta { get; set; }
    }
}
