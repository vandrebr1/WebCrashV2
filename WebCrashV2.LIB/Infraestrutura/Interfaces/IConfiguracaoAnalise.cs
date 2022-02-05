using System;
using System.Collections.Generic;
using WebCrashV2.LIB.Domain.ProcurarPadrao;

namespace WebCrashV2.LIB.Infraestrutura.Interfaces
{
    public interface IConfiguracaoAnalise
    {
        List<ResultadosPatterns> Iniciar(ConfiguracoesProcurarPadrao configuracoesProcurarPadrao);
        string Tipo { get; }

        int QuantidadeJogos { get; set; }
        DateTime DtDe { get; set; }

        DateTime DtAte { get; set; }

        int HoraUnica { get; set; }

    }
}
