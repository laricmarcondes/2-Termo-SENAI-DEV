using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Db.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data da consulta é obrigatória")]
        public DateTime DataConsulta { get; set; }

        public int? IdProntuario { get; set; }

        public int? IdMedico { get; set; }

        public int? IdSituacao { get; set; }

        public Medico IdMedicoNavigation { get; set; }
        public Prontuario IdProntuarioNavigation { get; set; }
        public Situacao IdSituacaoNavigation { get; set; }
    }
}
