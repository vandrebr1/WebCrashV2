using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrashV2.LIB.Infraestrutura.Interfaces;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace WebCrashV2.LIB.Domain.ProcurarPadrao
{
    public class AnaliseIntervaloDiasAgrupadoHora : IConfiguracaoAnalise
    {
        public AnaliseIntervaloDiasAgrupadoHora(DateTime dtDe, DateTime dtAte)
        {
            DtDe = dtDe;
            DtAte = dtAte;
        }

        public DateTime DtDe { get; set; }
        public DateTime DtAte { get; set; }
        public int HoraUnica { get; set; }

        public string Tipo => nameof(AnaliseIntervaloDiasAgrupadoHora);

        public int QuantidadeJogos { get; set; }

        public List<ResultadosPatterns> Iniciar(ConfiguracoesProcurarPadrao configuracoesProcurarPadrao)
        {
            return new List<ResultadosPatterns>();
        }
    }
}
