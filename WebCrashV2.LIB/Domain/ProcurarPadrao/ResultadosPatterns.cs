using System.Collections.Generic;

namespace WebCrashV2.LIB.Domain.ProcurarPadrao
{
    public class ResultadosPatterns
    {
        public ResultadosPatterns(int diferenca, int qtdAcertos, int qtdErros, string pattern, List<Resultado> resultados, int totalApostas)
        {
            QtdAcertos = qtdAcertos;
            QtdErros = qtdErros;
            Pattern = pattern;
            Resultados = resultados;
            Diferenca = diferenca;
            TotalApostas = totalApostas;
        }

        public int Diferenca { get; set; }

        public int QtdAcertos { get; set; }
        public int QtdErros { get; set; }
        public int TotalApostas { get; set; }
        public string Pattern { get; set; }
        public List<Resultado> Resultados { get; set; }


    }
}
