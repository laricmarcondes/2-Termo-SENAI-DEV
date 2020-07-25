using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Db.Domains
{
    public partial class EnderecoProntuario
    {
        public int IdEnderecoProntuario { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do endereço da consulta é obrigatório")]
        public string NomeEnderecoP { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O número do endereço da consulta é obrigatório")]
        public string Numero { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O bairro do endereço da consulta é obrigatório")]
        public string Bairro { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "A cidade do endereço da consulta é obrigatória")]
        public string Cidade { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O estado do endereço da consulta é obrigatório")]
        public string Estado { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O cep do endereço da consulta é obrigatório")]
        public string Cep { get; set; }

        public int? IdProntuario { get; set; }

        public Prontuario IdProntuarioNavigation { get; set; }
    }
}
