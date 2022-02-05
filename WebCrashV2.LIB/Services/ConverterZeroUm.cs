using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace WebCrashV2.LIB.Services
{
    public static class ConverterZeroUm
    {
        public static string Converter(List<TelaInformacoes> telaInformacoes, double valorBase)
        {
            string ret = "";

            foreach (var telainformacao in telaInformacoes)
            {
                if (telainformacao.HouveErroLeitura)
                {
                    ret += "9";
                }
                else if (telainformacao.Multiplicador >= valorBase)
                {
                    ret += "1";
                }
                else
                {
                    ret += "0";
                }
            }


            return ret;
        }
    }
}
