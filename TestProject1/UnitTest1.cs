using System;
using System.Diagnostics;
using System.Linq;
using WebCrashV2.LIB.Domain.Robo;
using WebCrashV2.LIB.Repository.DB;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CONSULTA_BANCO_ULTIMO_PATTERN()
        {
            string pattern = "000";
            var ultimosResultados = new TelaInformacoesRepository(new DBSession()).GetUltimosResultadosPattern(pattern.Length).ToList();

            foreach (var ultimo in ultimosResultados)
            {
                Debug.WriteLine($"{ultimo.Id} - {ultimo.Multiplicador}");
            }

            Assert.True(ultimosResultados.ElementAt(pattern.Length).Id > ultimosResultados.ElementAt(pattern.Length - 1).Id);
            /*double multiplicador = Convert.ToDouble("1.95");
            double valorAposta = Convert.ToDouble("100");

            var roboCrash = new RoboCrash(pattern, multiplicador, valorAposta);

            roboCrash.RoboIsApostar();*/
        }
    }
}
