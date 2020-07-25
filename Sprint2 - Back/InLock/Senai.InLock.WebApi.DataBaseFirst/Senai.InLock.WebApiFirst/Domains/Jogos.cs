using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApiFirst.Domains
{
    public partial class Jogos
    {
        public int IdJogo { get; set; }

        public string NomeJogo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataLancamento { get; set; }

        public double? Valor { get; set; }

        public int? IdEstudio { get; set; }

        public Estudios IdEstudioNavigation { get; set; }
    }
}
