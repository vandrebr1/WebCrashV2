using Serilog;
using System;

namespace WebCrashV2.LIB.Services
{
    public class JogoStatusService
    {

        private Navegador navegador;

        public JogoStatusService()
        {
            navegador = Navegador.GetInstance();
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

            try
            {
                navegador.FindElementByClassName("crash-game__mountains--game");
                return false;
            }
            catch
            {
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

        public bool UsuarioLogado()
        {
            try
            {
                var logado = navegador.FindElementByClassName("wrap_lk").Text;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
