using Serilog;
using System;
using System.Collections.Generic;
using WebCrashV2.LIB.Infraestrutura.Modelos;
using WebCrashV2.LIB.Observable;
using WebCrashV2.LIB.Repository.DB;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.LIB.Domain.Robo
{
    public class RoboCrash : IRoboObserver
    {
        private readonly List<string> Patterns;
        private readonly double Multiplicador;
        private readonly double TotalAposta;
        private TelaInformacoesRepository telaInformacoesRepository;
        private ContabilidadeRepository contabilidadeRepository;
        private bool isInAposta = false;
        private Contabilidade contabilidade;
        private string PatternApostado;
        NavegadorService Navegador;

        public RoboCrash(NavegadorService navegador, List<string> patterns, double multiplicador, double totalAposta)
        {
            Patterns = patterns;
            Multiplicador = multiplicador;
            TotalAposta = totalAposta;
            var dbSession = new DBSession();
            telaInformacoesRepository = new TelaInformacoesRepository(dbSession);
            contabilidadeRepository = new ContabilidadeRepository(dbSession);

            contabilidade = InicializarContabilidade(multiplicador, totalAposta);
            Navegador = navegador;

        }

        private Contabilidade InicializarContabilidade(double multiplicador, double totalAposta)
        {
            return new Contabilidade()
            {
                MultiplicadorApostado = multiplicador,
                ValorApostado = totalAposta,

            };
        }

        public void RoboIsApostar()
        {
            Log.Information($"Verificando Apostar");

            foreach (var pattern in Patterns)
            {
                var ultimosResultadosPattern = telaInformacoesRepository.GetUltimosResultadosPattern(pattern.Length);
                string ultimoPattern = ConvertPattern(ultimosResultadosPattern);

                if (ultimoPattern == pattern)
                {
                    Apostar(pattern);
                    break;
                }
                else
                {
                    Log.Information($"Pattern {pattern} # {ultimoPattern}");
                }

            }
        }

        private string ConvertPattern(List<TelaInformacoes> ultimosResultadosPattern)
        {
            string patternConvertido = "";

            foreach (var result in ultimosResultadosPattern)
            {
                if (result.HouveErroLeitura) // houve herro
                {
                    patternConvertido += "9";
                }
                else if (result.Multiplicador >= Multiplicador)
                {
                    patternConvertido += "1";
                }
                else
                {
                    patternConvertido += "0";
                }
            }

            return patternConvertido;
        }

        private void Apostar(string patternApostado)
        {
            isInAposta = true;
            PatternApostado = patternApostado;
            Navegador.SetElementById("crash-bet", TotalAposta);
            Navegador.ClickById("crash-btn crash-bet__btn crash-bet__btn--play");
            Log.Information($"Apostei: {TotalAposta} | multiplicador: {Multiplicador} | pattern: {PatternApostado}");
        }

        public void FinalizaAposta(double multiplicadorFinalizado)
        {
            if (isInAposta)
            {
                Derrota(multiplicadorFinalizado);
                Log.Information($"Rodada finalizada - Derrota: {TotalAposta * -1}");
            }
            else
            {

                Log.Information($"Rodada finalizada sem apostar");
            }

            isInAposta = false;
            PatternApostado = "";
        }

        private void Derrota(double multiplicadorFinalizado)
        {
            contabilidade.DataHora = DateTime.Now;
            contabilidade.VitoriaDerrota = "D";
            contabilidade.Valor = TotalAposta * -1;
            contabilidade.MultiplicadorCapturado = multiplicadorFinalizado;
            contabilidade.PatternApostado = PatternApostado;

            contabilidadeRepository.Salvar(contabilidade);
        }

        private void Vitoria(double multiplicadorFinalizado)
        {
            contabilidade.DataHora = DateTime.Now;
            contabilidade.VitoriaDerrota = "V";
            contabilidade.Valor = (TotalAposta * Multiplicador) - TotalAposta;
            contabilidade.MultiplicadorCapturado = multiplicadorFinalizado;
            contabilidade.PatternApostado = PatternApostado;

            contabilidadeRepository.Salvar(contabilidade);
        }

        public void ObterPremio(NavegadorService navegador)
        {
            if (isInAposta)
            {
                var multiplicadorAtual = ConvertDouble(navegador.FindElementByClassName("crash-game__counter").Text);

                if (multiplicadorAtual >= Multiplicador)
                {
                    Navegador.ClickById("crash-btn crash-bet__btn crash-bet__btn--stop");
                    Vitoria(multiplicadorAtual);
                    Log.Information($"Lucro Obtido: {(TotalAposta * Multiplicador) - TotalAposta }");
                    isInAposta = false;
                }
            }
        }



        //ARRUMAR CONVERT DOUBLE MULTIPLOS LUGARES
        private double ConvertDouble(string valor)
        {
            valor = valor.Replace("x", "").Replace(".", ",");
            return double.Parse(valor);
        }

    }
}
