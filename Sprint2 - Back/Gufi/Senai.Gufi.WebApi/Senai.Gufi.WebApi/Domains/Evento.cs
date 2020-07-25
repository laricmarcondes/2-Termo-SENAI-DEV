using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Presenca = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do evento é obrigatório!")]
        public string NomeEvento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data do evento é obrigatória!")]
        public DateTime DataEvento { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A descrição do evento é obrigatório!")]
        public string Descricao { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O tipo de acesso é obrigatório!")]
        public bool? AcessoLivre { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O id da instituição é obrigatório!")]
        public int? IdInstituicao { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O id do tipo de evento é obrigatório!")]
        public int? IdTipoEvento { get; set; }

        public Instituicao IdInstituicaoNavigation { get; set; }

        public TipoEvento IdTipoEventoNavigation { get; set; }

        public ICollection<Presenca> Presenca { get; set; }
    }
}
