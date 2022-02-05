using Dapper;
using System;

namespace WebCrashV2.LIB.Infraestrutura.Modelos
{
    [Table("Contabilidade")]
    public class Contabilidade
    {
        public Contabilidade()
        {
        }

        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public double MultiplicadorApostado { get; set; }
        public string PatternApostado { get; set; }
        public double ValorApostado { get; set; }
        public double MultiplicadorCapturado { get; set; }
        public string VitoriaDerrota { get; set; }
        public double Valor { get; set; }

    }
}
