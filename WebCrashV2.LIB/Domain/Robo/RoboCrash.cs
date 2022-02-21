using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using WebCrashV2.LIB.Infraestrutura.Modelos;
using WebCrashV2.LIB.Observable;
using WebCrashV2.LIB.Repository.DB;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.LIB.Domain.Robo
{
    public class RoboCrash : IRoboObserver
    {
        public bool PararApostas { get; set; } = false;
        private int QtdVitoriasDerrotas = 0;

        private readonly List<string> Patterns;
        private readonly List<string> PatternsIgnorar;

        private TelaInformacoesRepository telaInformacoesRepository;
        private ContabilidadeRepository contabilidadeRepository;
        private bool isInAposta = false;
        private Contabilidade contabilidade;
        private string PatternApostado;
        Navegador Navegador;
        Configuracoes Configuracoes;

        IWebElement btnReceber;
        IWebElement btnApostar;

        public RoboCrash(Configuracoes configuracoes, List<string> patterns, List<string> patternsIgnorar)
        {
            Patterns = patterns;
            PatternsIgnorar = patternsIgnorar;

            Configuracoes = configuracoes;
            var dbSession = new DBSession();
            telaInformacoesRepository = new TelaInformacoesRepository(dbSession);
            contabilidadeRepository = new ContabilidadeRepository(dbSession);

            contabilidade = InicializarContabilidade();
            Navegador = Navegador.GetInstance();

        }

        private void InicializaWebElements()
        {
            btnReceber = Navegador.FindElementByClassName("crash-bet__btn--stop");
            btnApostar = Navegador.FindElementByClassName("crash-bet__btn--play");
        }

        private Contabilidade InicializarContabilidade()
        {
            return new Contabilidade()
            {
                MultiplicadorApostado = Configuracoes.Multiplicador,
                ValorApostado = Configuracoes.ValorAposta,
            };
        }

        public void RoboIsApostar()
        {
            Log.Information($"Verificando Apostar");

            if (ExistirSomentePatternsValidos())
            {
                foreach (var pattern in Patterns)
                {
                    var ultimosResultadosPattern = telaInformacoesRepository.GetUltimosResultadosPattern(pattern.Length);
                    string ultimoPattern = ConvertPattern(ultimosResultadosPattern);

                    if (ultimoPattern == pattern)
                    {
                        Log.Information($"Encontrei, Pattern {pattern} compativel");
                        Apostar(pattern);
                        break;
                    }
                    else
                    {
                        Log.Information($"Pattern {pattern} # {ultimoPattern}");
                    }

                }
            }
        }

        private bool ExistirSomentePatternsValidos()
        {
            Log.Information($"Verificando Ignorar Aposta");

            foreach (var patternsIgnorar in PatternsIgnorar)
            {
                var ultimosResultadosPattern = telaInformacoesRepository.GetUltimosResultadosPattern(patternsIgnorar.Length);
                string ultimoPattern = ConvertPattern(ultimosResultadosPattern);

                if (ultimoPattern.Contains("9"))
                {
                    Log.Information($"Ignorar Pattern que contem 9: {ultimoPattern}");
                    return false;
                }

                if (ultimoPattern == patternsIgnorar)
                {
                    Log.Information($"Ignorar Pattern  {patternsIgnorar} = {ultimoPattern}");
                    return false;
                }
            }

            Log.Information($"Nenhum Pattern Ignorar");
            return true;
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
                else if (result.Multiplicador >= Configuracoes.Multiplicador)
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

            ClicarEmApostar();

            Log.Information($"Apostei: {Configuracoes.ValorAposta} | multiplicador: {Configuracoes.Multiplicador} | pattern: {PatternApostado}");
        }



        public void FinalizaAposta(double multiplicadorFinalizado)
        {
            if (isInAposta)
            {
                Derrota(multiplicadorFinalizado);
                Log.Information($"Rodada finalizada - Derrota: {Configuracoes.ValorAposta * -1}");
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
            contabilidade.Valor = Configuracoes.ValorAposta * -1;
            contabilidade.MultiplicadorCapturado = multiplicadorFinalizado;
            contabilidade.PatternApostado = PatternApostado;

            contabilidadeRepository.Salvar(contabilidade);

            QtdVitoriasDerrotas--;


        }

        private void Vitoria(double multiplicadorFinalizado)
        {
            contabilidade.DataHora = DateTime.Now;
            contabilidade.VitoriaDerrota = "V";
            contabilidade.Valor = (Configuracoes.ValorAposta * Configuracoes.Multiplicador) - Configuracoes.ValorAposta;
            contabilidade.MultiplicadorCapturado = multiplicadorFinalizado;
            contabilidade.PatternApostado = PatternApostado;

            contabilidadeRepository.Salvar(contabilidade);
            QtdVitoriasDerrotas++;
        }

        public void ObterPremio(IWebElement elementCrashGameCounter)
        {
            if (isInAposta)
            {
                var multiplicadorAtual = ConvertDouble(elementCrashGameCounter.Text);

                if (multiplicadorAtual >= (Configuracoes.Multiplicador - 0.10))
                {
                    Receber(); // Não inverter a ordem disso
                    Log.Information($"Receber premiação");

                    Vitoria(multiplicadorAtual);
                    Log.Information($"Lucro Obtido: {(Configuracoes.ValorAposta * Configuracoes.Multiplicador) - Configuracoes.ValorAposta}");
                    isInAposta = false;
                }
            }
        }

        private void Receber()
        {
            try
            {
                if (Configuracoes.ApostarPraValer) { 
                btnReceber.Click();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Erro CATASTROFICO em Receber() {ex.Message} parar TUDO!");
                Navegador.CapturarImagemTela(nameof(Receber));

                try
                {
                    //Tentar receber de qualquer maneira;
                    btnReceber = Navegador.FindElementByClassName("crash-bet__btn--stop");
                    btnReceber.Click();
                }
                catch (Exception ex1)
                {
                    Log.Error($"Erro CATASTROFICO em Receber() Impossível receber {ex1.Message} parar TUDO!");
                }

            }
        }

        //ARRUMAR CONVERT DOUBLE MULTIPLOS LUGARES
        private double ConvertDouble(string valor)
        {
            valor = valor.Replace("x", "").Replace(".", ",");
            return double.Parse(valor);
        }

        private void ClicarEmApostar()
        {
            if (Configuracoes.ApostarPraValer && ContinuarJogando())
            {
                InicializaWebElements();
                Log.Information($"Apostei para valer");


                DifarcarBotTempoEntradas();
                //DisfarcarBotPosicaoMouseById("crash-bet");
                Navegador.SetElementById("crash-bet", Configuracoes.ValorAposta);

                var valorNoInput = Navegador.FindElementById("crash-bet").GetAttribute("value");

                if (Configuracoes.ValorAposta.ToString() == valorNoInput)
                {
                    DifarcarBotTempoEntradas();
                    //DisfarcarBotPosicaoMouse(btnApostar);
                    try
                    {
                        //Descomentar para Jogar mesmo!!
                        Navegador.ClickByElemento(btnApostar);
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Erro CATASTROFICO em ClicarEmApostar() {ex.Message} parar TUDO!");
                        Navegador.CapturarImagemTela(nameof(ClicarEmApostar));
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Log.Error($"Erro ClicarEmApostar() Valor do input {valorNoInput} <> valor apostar {Configuracoes.ValorAposta}");
                }
            }
        }

        private void DifarcarBotTempoEntradas()
        {
            Random rnd = new Random();
            int milesegundosEsperar = rnd.Next(2000, 3000);

            Thread.Sleep(milesegundosEsperar);
        }

        private void DisfarcarBotPosicaoMouse(IWebElement elemento)
        {
            Navegador.MoveMouse(elemento);
        }

        private void DisfarcarBotPosicaoMouseById(string Id)
        {
            var elemento = Navegador.FindElementById(Id);
            Navegador.MoveMouse(elemento);
        }

        public bool ContinuarJogando()
        {
            var result = !(QtdVitoriasDerrotas <= Configuracoes.QtdNegativasParar || QtdVitoriasDerrotas >= Configuracoes.QtdPositivasParar);

            var continuarJogando = result ? "SIM" : "NÃO";
            Log.Information($"Continuar jogando?: {continuarJogando} ( {QtdVitoriasDerrotas} <= {Configuracoes.QtdNegativasParar} || {QtdVitoriasDerrotas} >= {Configuracoes.QtdPositivasParar} )");

            return result;
        }

        public void ForcarReceberPremio()
        {
            Log.Error($"Forçar receber!");
            btnReceber = Navegador.FindElementByClassName("crash-bet__btn--stop");

            try
            {
                if (btnReceber.Enabled)
                {
                    btnReceber.Click();
                }
                else
                {
                    btnReceber = Navegador.FindElementByClassName("crash-bet__btn--stop");
                    btnReceber.Click();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Erro em ForcarReceberPremio() {ex.Message}");
            }

        }
    }
}
