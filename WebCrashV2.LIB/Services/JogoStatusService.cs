using Serilog;
using System;

namespace WebCrashV2.LIB.Services
{
    public class JogoStatusService
    {

        private NavegadorService navegador;

        public JogoStatusService(NavegadorService navegador)
        {
            this.navegador = navegador;
        }

        public bool JogoFinalizou()
        {
            var finalizou = navegador.FindElementByClassName("crash-bet__type");

            if (finalizou.Enabled)
            {
                return false;
            }
            else
            {
                Log.Information($"Jogo finalizou");
                return true;
            }
        }

        public bool AviaoExplodiu()
        {

            var aviaoVoando = navegador.FindElementsByClassName("crash-game__mountains--game");

            if (aviaoVoando.Count > 0)
            {
                return false;
            }
            else
            {
                Log.Information($"Avião explodiu");
                return true;
            }
        }

        public bool ContagemRegressivaIniciou()
        {
            string contagemRegressiva = navegador.FindElementByClassName("crash-game__timer").Text;

            if (contagemRegressiva != "")
            {
                Log.Information($"Contagem regressiva iniciou");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MultiplicadorIniciou()
        {
            string identificadorInicio = navegador.FindElementByClassName("crash-game__counter").Text;

            identificadorInicio = identificadorInicio.ToUpper().Replace("X", "").Replace(".", ",");

            if (identificadorInicio != "")
            {
                double valorIdentificador = Convert.ToDouble(identificadorInicio);

                if (valorIdentificador >= 1)
                {
                    Log.Information($"Multiplicador iniciou");
                    return true;
                }
            }

            return false;
        }
    }
}
