using Serilog;
using System;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace WebCrashV2.LIB.Services
{
    public class CapturaDadosTela
    {
        readonly Navegador Navegador;
        private bool houveErroLeitura;

        public CapturaDadosTela()
        {
             Navegador = Navegador.GetInstance();
        }      

        public TelaInformacoes ConvertToTelaInformacoes()
        {
            var multiplicador = GetMultiplicador();
            var horarioCaptura = GetHorarioCaptura();
            var erroLeitura = GetHouveErroLeitura();

            var telaInformacoes = new TelaInformacoes(multiplicador, horarioCaptura, erroLeitura);
            return telaInformacoes;
        }

        private string GetMultiplicador()
        {
            try
            {
                return Navegador.FindElementByClassName("crash-game__counter").Text;
            }
            catch (Exception ex)
            {
                Log.Error($"Erro ao capturar valor GetMultiplicador(): {ex.Message}");
                houveErroLeitura = true;
            }

            return "0";
        }        

        private bool GetHouveErroLeitura()
        {
            return houveErroLeitura;
        }

        public DateTime GetHorarioCaptura()
        {
            return DateTime.Now;
        }
    }
}
