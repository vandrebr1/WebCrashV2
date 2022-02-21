using System;
using System.Collections.Generic;
using System.Linq;
using WebCrashV2.LIB.Infraestrutura.Interfaces;
using WebCrashV2.LIB.Repository.DB;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.LIB.Domain.ProcurarPadrao
{
    public class AnaliseIntervaloDias : IConfiguracaoAnalise
    {
        public AnaliseIntervaloDias(DateTime dtDe, DateTime dtAte)
        {
            DtDe = dtDe;
            DtAte = dtAte;

        }

        public DateTime DtDe { get; set; }
        public DateTime DtAte { get; set; }
        public int HoraUnica { get; set; }

        public string Tipo => nameof(AnaliseIntervaloDias);

        public int QuantidadeJogos { get; set; }

        public List<ResultadosPatterns> Iniciar(ConfiguracoesProcurarPadrao configuracoesProcurarPadrao)
        {
            var telaInformacaoRepository = new TelaInformacoesRepository(new DBSession());
            var registros = telaInformacaoRepository.SelecionarTodosByDtDeDtAte(DtDe, DtAte).ToList();
            var strZerosUns = ConverterZeroUm.Converter(registros, configuracoesProcurarPadrao.MultiplicadorAnalisado);

            DtAte = registros.Max(e => e.HorarioCaptura);
            DtDe = registros.Min(e => e.HorarioCaptura);
            QuantidadeJogos = strZerosUns.Length;
            HoraUnica = -1;

            var resultados = AnaliseProcurarPadrao.Procurar(strZerosUns, configuracoesProcurarPadrao.QtdCaracteresPattern);

            return resultados;
        }

    }
}
