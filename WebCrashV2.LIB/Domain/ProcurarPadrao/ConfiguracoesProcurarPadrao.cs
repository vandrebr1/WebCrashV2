namespace WebCrashV2.LIB.Domain.ProcurarPadrao
{
    public class ConfiguracoesProcurarPadrao
    {
        public ConfiguracoesProcurarPadrao(int qtdCaracteresPattern, double multiplicadorAnalisado, double valorApostaCalcular)
        {
            QtdCaracteresPattern = qtdCaracteresPattern;
            MultiplicadorAnalisado = multiplicadorAnalisado;
            ValorApostaCalcular = valorApostaCalcular;
        }

        public int QtdCaracteresPattern { get; set; }

        public double MultiplicadorAnalisado { get; set; }

        public double ValorApostaCalcular { get; set; }

    }
}
