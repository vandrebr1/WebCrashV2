using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebCrashV2.LIB.Domain.ConfiguracoesAtivas;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PARAR_JOGAR_NEGATIVO_POSITIVO()
        {
            var testeConfig = new Configuracoes(0, 2, 100, true, -5, 5);
            ConfiguracaoAtiva.SetInstance(testeConfig);
            var config = ConfiguracaoAtiva.GetInstance();

            var totalGanhosNegativo = -5;
            var pararPqAtigingiuNegativo = totalGanhosNegativo <= config.QtdNegativasParar;
            Assert.IsTrue(pararPqAtigingiuNegativo);

            var totalGanhosPositivo = 5;
            var pararPqAtigingiuPositivo = totalGanhosPositivo >= config.QtdPositivasParar;
            Assert.IsTrue(pararPqAtigingiuPositivo);


            var pararPqAtigingiuPositivoNegativo = (totalGanhosNegativo <= config.QtdNegativasParar || totalGanhosPositivo >= config.QtdPositivasParar);
            Assert.IsTrue(pararPqAtigingiuPositivoNegativo);

            var totalGanho = -4;
            var pararPqAtigingiuPositivoNegativo1 = (totalGanho <= config.QtdNegativasParar || totalGanho >= config.QtdPositivasParar);
            Assert.IsFalse(pararPqAtigingiuPositivoNegativo1);

        }

    }
}
