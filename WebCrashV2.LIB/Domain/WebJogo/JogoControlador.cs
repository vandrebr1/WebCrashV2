using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using WebCrashV2.LIB.Infraestrutura.Modelos;
using WebCrashV2.LIB.Observable;
using WebCrashV2.LIB.Repository.DB;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.LIB.Domain.WebJogo
{
    public class JogoControlador : IJogoSubject
    {
        private NavegadorService navegador;
        private JogoStatusService jogoCaptura;
        private TelaInformacoesRepository telaInformacoesRepository;
        private List<IRoboObserver> _roboObservers = new List<IRoboObserver>();
        //private const int RODADAS_ATUALIZA_PAGINA = 10;
        //private int refreshPagina = 0;

        public JogoControlador()
        {
            navegador = new NavegadorService();
            jogoCaptura = new JogoStatusService(navegador);
            telaInformacoesRepository = new TelaInformacoesRepository(new DBSession());
        }

        public void Iniciar()
        {
            try
            {
                AguardarAbrirNavegador();
                AguardaContagemRegressivaIniciar(40);

                while (true)
                {
                    CapturaInformacoes();
                }
            }
            catch (Exception ex)
            {
                FinalizaAposta(-1);
                Log.Error($"Erro em JogoControladorIniciar() não prevista {ex.Message}");
            }

        }

        private void SalvarInformacoesJogoErro()
        {
            Log.Information($"SALVANDO INFORMAÇÕES ERRO LEITURA!");

            telaInformacoesRepository.Salvar(TelaInformacoes.MontarRegistroErroLeitura());
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
            try
            {
                AguardaContagemRegressivaIniciar(20);
                IsApostar();
                AguardaMultiplicadorIniciar();
                AguardarAviaoExplodiu();
                SalvarInformacoes();

                /*if (refreshPagina == RODADAS_ATUALIZA_PAGINA)
                {
                    navegador.ReiniciarNavegacao();
                    refreshPagina = 0;
                }
                else
                {
                    refreshPagina++;
                }*/
            }
            catch (Exception ex)
            {
                Log.Error($"CapturaInformacoes() {ex.Message}");
                FinalizaAposta(-1);
                SalvarInformacoesJogoErro();
                navegador.ReiniciarNavegacao();
            }

        }

        private void SalvarInformacoes()
        {
            var capturaTela = new CapturaDadosTela(navegador);
            var telaInformacoes = capturaTela.ConvertToTelaInformacoes();

            Log.Information($"SALVANDO INFORMAÇÕES");

            telaInformacoesRepository.Salvar(telaInformacoes);
            FinalizaAposta(telaInformacoes.Multiplicador);

        }

        private bool AguardarAviaoExplodiu()
        {
            DateTime dtInicial = DateTime.Now;

            while (!jogoCaptura.AviaoExplodiu())
            {
                IsObterPremio(navegador);

                //Thread.Sleep(5);

                if (JogoDemorandoMuitoParaIniciar(dtInicial, 40))
                    throw new Exception("Jogo demorou muito para avião explodir!");
            }

            return true;
        }


        private bool AguardaMultiplicadorIniciar()
        {
            DateTime dtInicial = DateTime.Now;

            while (!jogoCaptura.MultiplicadorIniciou())
            {
                Thread.Sleep(50);

                if (JogoDemorandoMuitoParaIniciar(dtInicial, 17))
                    throw new Exception("Jogo demorou muito para iniciar multiplicador!");
            }

            return true;
        }

        private bool AguardaContagemRegressivaIniciar(int tempoEspera)
        {
            DateTime dtInicial = DateTime.Now;

            while (!jogoCaptura.ContagemRegressivaIniciou())
            {
                Thread.Sleep(25);

                if (JogoDemorandoMuitoParaIniciar(dtInicial, tempoEspera))
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

        public void AttachRobo(IRoboObserver observer)
        {
            _roboObservers.Add(observer);
        }

        public void Detach(IRoboObserver observer)
        {
            _roboObservers.Remove(observer);
        }

        public void IsApostar()
        {
            foreach (var observerRobo in _roboObservers)
            {
                observerRobo.RoboIsApostar();
            }
        }

        public void IsObterPremio(NavegadorService navegador)
        {
            _roboObservers[0].ObterPremio(navegador);
            /*foreach (var observerRobo in _roboObservers)
            {
                observerRobo.ObterPremio(navegador);
            }*/
        }

        public void FinalizaAposta(double multiplicadorFinalizado)
        {
            foreach (var observerRobo in _roboObservers)
            {
                observerRobo.FinalizaAposta(multiplicadorFinalizado);
            }
        }
    }
}
