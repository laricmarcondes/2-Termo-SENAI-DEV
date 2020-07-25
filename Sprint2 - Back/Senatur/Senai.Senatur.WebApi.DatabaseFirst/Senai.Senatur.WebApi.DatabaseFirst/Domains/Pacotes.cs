using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.DatabaseFirst.Domains
{
    public partial class Pacotes
    {
        public int IdPacote { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do pacote é obrigatório")]
        public string NomePacote { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A descrição do pacote é obrigatória")]
        public string Descricao { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data de ida do pacote é obrigatória")]
        public DateTime DataIda { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A data de volta do pacote é obrigatória")]
        public DateTime DataVolta { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O preço do pacote é obrigatório")]
        public decimal Valor { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe a atividade do pacote")]
        public string Ativo { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome da cidade do pacote é obrigatório")]
        
        public string NomeCidade { get; set; }
    }
}
