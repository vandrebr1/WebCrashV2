using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebCrashV2.LIB.Services
{
    public sealed class Navegador
    {
        private readonly string PAGINA = "https://betwinner.com/pt/allgamesentrance/crash/";


        private IWebDriver webDriver;
        private WebDriverWait webDriverWait;
        private ChromeOptions chromeOptions;
        Actions action;

        public Navegador()
        {
            Inicializar();
        }

        private static Navegador _NavegadorService;

        public static Navegador GetInstance()
        {
            if (_NavegadorService == null)
            {
                _NavegadorService = new Navegador();
            }
            return _NavegadorService;
        }

        private void Inicializar()
        {
            var configuracoesJson = new ConfiguracoesJson();

            chromeOptions = new ChromeOptions();
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddAdditionalOption("useAutomationExtension", false);
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            chromeOptions.AddArgument($"--user-data-dir={configuracoesJson.GetUserDataDir()}");
            chromeOptions.AddArgument($"--profile-directory={configuracoesJson.GetProfileDirectory()}");

            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(240));
            action = new Actions(webDriver);

        }

        public bool AbrirNavegadorParaTeste(string url)
        {
            webDriver.Navigate().GoToUrl(url);
            return true;
        }

        public bool AbrirNavegador()
        {
            webDriver.Navigate().GoToUrl(PAGINA);
            AguardarConfirmacaoPaginaAberta();

            return true;
        }

        public bool ReiniciarNavegacao()
        {
            webDriver.Navigate().Refresh();
            AguardarConfirmacaoPaginaAberta();

            return true;
        }

        private void AguardarConfirmacaoPaginaAberta()
        {
            try
            {
                webDriverWait.Until(driver => driver.FindElement(By.ClassName("crash-game__wrap")).Displayed);
            }
            catch (Exception ex)
            {

                Log.Error($"Pagina não carregada: { ex.Message} ");
                throw ex;
            }
        }

        public IWebElement FindElementByClassName(string className)
        {
            try
            {
                return webDriver.FindElement(By.ClassName(className));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IWebElement FindElementById(string Id)
        {
            try
            {
                return webDriver.FindElement(By.Id(Id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<IWebElement> FindElementsByClassName(string classname)
        {
            List<IWebElement> ret = new List<IWebElement>();

            try
            {
                ret.AddRange(webDriver.FindElements(By.ClassName(classname)));
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SetElementById(string id, double valor)
        {

            try
            {
                var elemento = webDriver.FindElement(By.Id(id));

                if (elemento.Enabled)
                {
                    SetInputValorApostaEmZero();
                    Thread.Sleep(100);
                    elemento.Click();
                    elemento.SendKeys(valor.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Warning($"Erro em SetElementById() {ex.Message} | Verificar");
                //throw new Exception(ex.Message);
            }
        }

        public void SetInputValorApostaEmZero()
        {
            try
            {
                var elemento = FindElementByClassName("crash-bet-form__btn--reset");

                if (elemento.Enabled)
                {
                    elemento.Click();
                }

            }
            catch (Exception ex)
            {
                Log.Warning($"Erro em SetElementEmZeroById() {ex.Message} | Verificar");
                //throw new Exception(ex.Message);
            }
        }


        public void ClickByClass(string classname)
        {
            var btn = FindElementByClassName(classname);

            try
            {
                btn.Click();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ClickByElemento(IWebElement btn)
        {
            try
            {
                btn.Click();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro em ClickByElemento() {ex.Message}");
            }
        }

        public void MoveMouse(IWebElement elemento)
        {
            try
            {
                var rnd = new Random();
                var larguraMax = elemento.Size.Width - 1;
                var alturaMax = elemento.Size.Height - 1;

                int rndX = rnd.Next(1, larguraMax);
                int rndY = rnd.Next(1, alturaMax);

                action.MoveToElement(elemento, rndX, rndY).Perform();
            }
            catch (Exception ex)
            {
                Log.Warning($"Erro em  MoveMouse() {ex.Message} | Verificar");
            }

        }

        public void CapturarImagemTela(string nomeFuncao)
        {
            string caminho = AppDomain.CurrentDomain.BaseDirectory;
            string subPath = "\\_logsprints";
            string caminhoCompleto = caminho + subPath;
            string nomeArquivo = $"{nomeFuncao}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png";

            bool exists = Directory.Exists(caminhoCompleto);

            if (!exists)
                Directory.CreateDirectory(caminhoCompleto);

            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            ss.SaveAsFile($"{caminhoCompleto}\\{nomeArquivo}", ScreenshotImageFormat.Png);
        }

    }
}
