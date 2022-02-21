using OpenQA.Selenium;
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
        private readonly Navegador Navegador;
        private JogoStatusService jogoCaptura;
        private TelaInformacoesRepository telaInformacoesRepository;
        private List<IRoboObserver> _roboObservers = new List<IRoboObserver>();
        private CapturaDadosTela capturaTela = new CapturaDadosTela();
        public JogoControlador()
        {
            Navegador = Navegador.GetInstance();
            jogoCaptura = new JogoStatusService();
            telaInformacoesRepository = new TelaInformacoesRepository(new DBSession());
        }

        public void Iniciar()
        {
            try
            {
                SalvarInformacoesJogoErro();
                AguardarAbrirNavegador();
                AguardaContagemRegressivaIniciar(40);

                while (true)
                {
                    Navegador.SetInputValorApostaEmZero();
                    CapturaInformacoes();
                }
            }
            catch (Exception ex)
            {
                FinalizaAposta(-1);
                Log.Error($"Erro em Iniciar() não prevista {ex.Message} LINHA 35");
            }

        }

        private void SalvarInformacoesJogoErro()
        {
            Log.Information($"SALVANDO INFORMAÇÕES ERRO LEITURA!");

            telaInformacoesRepository.Salvar(TelaInformacoes.MontarRegistroErroLeitura());
        }

        public bool AguardarAbrirNavegador()
        {
            bool navegadorAberto = Navegador.AbrirNavegador();

            while (!navegadorAberto)
            {
                navegadorAberto = Navegador.ReiniciarNavegacao();
            }

            return true;
        }


        private void CapturaInformacoes()
        {
            int linhaErro = 0;

            try
            {
                linhaErro = 1;
                AguardaContagemRegressivaIniciar(20);

                linhaErro = 2;
                IsApostar();

                linhaErro = 3;
                AguardaMultiplicadorIniciar();

                linhaErro = 4;
                AguardarAviaoExplodiu();

                linhaErro = 5;
                SalvarInformacoes();

            }
            catch (Exception ex)
            {
                Log.Error($"Erro em CapturaInformacoes() {ex.Message} Linha {linhaErro} \n{ex.StackTrace} ");
                Navegador.CapturarImagemTela(nameof(CapturaInformacoes));
                FinalizaAposta(-1);
                SalvarInformacoesJogoErro();
                Navegador.ReiniciarNavegacao();
            }

        }

        private void SalvarInformacoes()
        {
            var telaInformacoes = capturaTela.ConvertToTelaInformacoes();

            Log.Information($"SALVANDO INFORMAÇÕES");

            telaInformacoesRepository.Salvar(telaInformacoes);
            FinalizaAposta(telaInformacoes.Multiplicador);
        }

        private bool AguardarAviaoExplodiu()
        {
            try
            {
                DateTime dtInicial = DateTime.Now;

                IWebElement crashGameCounter = Navegador.FindElementByClassName("crash-game__counter");

                while (!jogoCaptura.AviaoExplodiu())
                {
                    IsObterPremio(crashGameCounter);

                    if (JogoDemorandoMuitoParaIniciar(dtInicial, 40))
                        throw new Exception("Jogo demorou muito para avião explodir!");

                    Thread.Sleep(5);
                }
            }
            catch (Exception ex)
            {
                Log.Warning($"Erro em AguardarAviaoExplodiu() {ex.Message}");
                ForcarReceberPremio();
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
            _roboObservers[0].RoboIsApostar();

        }

        public void IsObterPremio(IWebElement crashGameCounter)
        {

            _roboObservers[0].ObterPremio(crashGameCounter);

        }

        private void ForcarReceberPremio()
        {
            _roboObservers[0].ForcarReceberPremio();
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
