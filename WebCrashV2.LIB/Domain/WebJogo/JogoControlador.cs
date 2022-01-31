using Serilog;
using System;
using System.Threading;
using WebCrashV2.LIB.Repository.DB;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.LIB.Domain.WebJogo
{
    public class JogoControlador
    {
        private NavegadorService navegador;
        private JogoStatusService jogoCaptura;
        private TelaInformacoesRepository telaInformacoesRepository;

        public JogoControlador()
        {
            navegador = new NavegadorService();
            jogoCaptura = new JogoStatusService(navegador);
            telaInformacoesRepository = new TelaInformacoesRepository(new DBSession());
        }

        public void Iniciar()
        {

            AguardarAbrirNavegador();

            while (true)
            {
                CapturaInformacoes();
            }

        }

        public bool AguardarAbrirNavegador()
        {
            bool navegadorAberto = navegador.AbrirNavegador();

            while (!navegadorAberto)
            {
                navegadorAberto = navegador.ReiniciarNavegacao();
            }

            return true;
        }


        private void CapturaInformacoes()
        {
            AguardaContagemRegressivaIniciar();
            AguardaMultiplicadorIniciar();
            AguardarAviaoExplidiu();
            SalvarInformacoes();

        }

        private void SalvarInformacoes()
        {
            var capturaTela = new CapturaDadosTela(navegador);
            var telaInformacoes = capturaTela.ConvertToTelaInformacoes();

            Log.Information($"SALVANDO INFORMAÇÕES");

            telaInformacoesRepository.Salvar(telaInformacoes);

        }

        private bool AguardarAviaoExplidiu()
        {
            DateTime dtInicial = DateTime.Now;

            while (!jogoCaptura.AviaoExplodiu())
            {
                Thread.Sleep(10);

                if (JogoDemorandoMuitoParaIniciar(dtInicial, 40))
                    throw new Exception("Jogo demorou muito para avião explodir!");
            }

            return true;
        }

        private bool AguardaJogoFinalizou()
        {
            DateTime dtInicial = DateTime.Now;

            while (!jogoCaptura.JogoFinalizou())
            {
                Thread.Sleep(10);

                if (JogoDemorandoMuitoParaIniciar(dtInicial, 20))
                    throw new Exception("Jogo demorou muito para Finalizar!");
            }

            return true;
        }

        private bool AguardaMultiplicadorIniciar()
        {
            DateTime dtInicial = DateTime.Now;

            while (!jogoCaptura.MultiplicadorIniciou())
            {
                Thread.Sleep(50);

                if (JogoDemorandoMuitoParaIniciar(dtInicial, 20))
                    throw new Exception("Jogo demorou muito para iniciar multiplicador!");
            }

            return true;
        }

        private bool AguardaContagemRegressivaIniciar()
        {
            DateTime dtInicial = DateTime.Now;

            while (!jogoCaptura.ContagemRegressivaIniciou())
            {
                Thread.Sleep(50);

                if (JogoDemorandoMuitoParaIniciar(dtInicial, 20))
                    throw new Exception("Jogo demorou muito para iniciar contagem regressiva!");
            }

            return true;
        }

        private static bool JogoDemorandoMuitoParaIniciar(DateTime dtInicial, int segundosEsperar)
        {
            DateTime horaAtual = DateTime.Now;

            TimeSpan span = horaAtual.Subtract(dtInicial);

            if (span.Seconds >= segundosEsperar)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
