using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrashV2.LIB.Infraestrutura.Modelos
{
    [Table("Analises")]
    public class Analise
    {
        public int Id { get; set; }
        public string Pattern { get; set; }
        public int Diferenca { get; set; }
        public int Acertos { get; set; }
        public int Erros { get; set; }
        public int TotalApostas { get; set; }
        public double Ganhos { get; set; }
        public DateTime DtAnalisado { get; set; }
        public int QuantidadeJogos { get; set; }
        public string TipoAnalise { get; set; }
        public DateTime? DtDe { get; set; }
        public DateTime? DtAte { get; set; }
        public int? HoraUnica { get; set; }
        public decimal ProporcaoAcertosErros { get; set; }
        public int NumeroCaracteres { get; set; }
        public int ValorEmDecimal { get; set; }
    }
}
