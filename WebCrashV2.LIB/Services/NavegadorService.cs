using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebCrashV2.LIB.Services
{
    public class NavegadorService
    {
        private readonly string PAGINA = "https://betwinner.com/pt/allgamesentrance/crash/";

        private IWebDriver webDriver;
        private WebDriverWait webDriverWait;
        private ChromeOptions chromeOptions;

        public NavegadorService()
        {
            Inicializar();
        }

        private void Inicializar()
        {
            chromeOptions = new ChromeOptions();

            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddAdditionalOption("useAutomationExtension", false);
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;

            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(240));

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

    }
}
