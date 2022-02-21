using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebCrashV2.LIB.Services;

namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MoverMouse()
        {
            var classeElemento = "menuDesktop__link__title";
            var navegador = Navegador.GetInstance();

            navegador.AbrirNavegadorParaTeste("https://www.uol.com.br/");

            var elemento = navegador.FindElementByClassName(classeElemento);

            navegador.MoveMouse(elemento);

        }

        [TestMethod]
        public void SalvarPrint()
        {
            var navegador = Navegador.GetInstance();
            navegador.AbrirNavegadorParaTeste("https://www.uol.com.br/");

            navegador.CapturarImagemTela(nameof(SalvarPrint));

        }
    }
}
