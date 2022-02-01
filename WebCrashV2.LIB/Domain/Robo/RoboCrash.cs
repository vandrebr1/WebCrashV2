using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrashV2.LIB.Infraestrutura.Modelos;
using WebCrashV2.LIB.Observable;
using WebCrashV2.LIB.Repository.DB;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.LIB.Domain.Robo
{
    public class RoboCrash : IRoboObserver
    {
        private readonly string Pattern;
        private readonly double Multiplicador;
        private readonly double TotalAposta;
        private TelaInformacoesRepository telaInformacoesRepository;
        private bool isInAposta = false;

        public RoboCrash(string pattern, double multiplicador, double totalAposta)
        {
            Pattern = pattern;
            Multiplicador = multiplicador;
            TotalAposta = totalAposta;

            telaInformacoesRepository = new TelaInformacoesRepository(new DBSession());
        }

        public void RoboIsApostar()
        {
            Log.Information($"Verificando Apostar");
            var ultimosResultadosPattern = telaInformacoesRepository.GetUltimosResultadosPattern(Pattern.Length);
            string ultimoPattern = ConvertPattern(ultimosResultadosPattern);

            if (ultimoPattern == Pattern)
            {
                Apostar();
            }
            else
            {
                Log.Information($"Pattern {Pattern} # {ultimoPattern}");
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

        private void Apostar()
        {
            isInAposta = true;
            Log.Information($"Apostei: {TotalAposta} no multiplicador {Multiplicador}");
        }

        public void FinalizaAposta()
        {
            if (isInAposta)
            {
                Log.Information($"Rodada finalizada - Derrota: {TotalAposta * -1}");
            }
            else
            {

                Log.Information($"Rodada finalizada sem apostar");
            }

            isInAposta = false;
        }

        public void ObterPremio(NavegadorService navegador)
        {
            if (isInAposta)
            {
                var multiplicadorAtual = ConvertDouble(navegador.FindElementByClassName("crash-game__counter").Text);

                if (multiplicadorAtual >= Multiplicador)
                {
                    Log.Information($"Lucro Obtido: {(TotalAposta * Multiplicador) - TotalAposta  }");
                    isInAposta = false;
                }
            }
        }

        //ARRUMAR CONVERT DOUBLE MULTIPLOS LUGARES
        private double ConvertDouble(string valor)
        {
            valor = valor.ToUpper().Replace("X", "").Replace(".", ",").Replace("RUB", "").Replace("BRL", "").Trim();
            return Convert.ToDouble(valor);
        }

    }
}
