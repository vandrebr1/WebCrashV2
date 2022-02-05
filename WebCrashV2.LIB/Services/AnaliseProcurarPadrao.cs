using System.Collections.Generic;
using System.Linq;
using WebCrashV2.LIB.Domain.ProcurarPadrao;

namespace WebCrashV2.LIB.Services
{
    public static class AnaliseProcurarPadrao
    {
        public static List<ResultadosPatterns> Procurar(string strZerosUns, int qtdCaracteresPattern)
        {
            List<ResultadosPatterns> rsPatterns = new List<ResultadosPatterns>();

            for (int i = 1; i <= qtdCaracteresPattern; i++)
            {
                var binarios = new GerarStringsBinaria(i);

                foreach (string patternGerado in binarios.StringsBinaria)
                {
                    List<Resultado> resultados = new List<Resultado>();

                    for (int posTexto = 0; posTexto <= (strZerosUns.Length - patternGerado.Length); posTexto++)
                    {
                        //Corrigi o bug ArrayOutOfBound
                        if (posTexto + patternGerado.Length >= strZerosUns.Length) break;

                        string textoEncontrado = strZerosUns.Substring(posTexto, patternGerado.Length);
                        string proximoValor = strZerosUns.Substring(posTexto + patternGerado.Length, 1);

                        if (textoEncontrado == patternGerado)
                        {
                            var resultado = new Resultado()
                            {
                                Posicao = posTexto + patternGerado.Length,
                                Pattern = patternGerado
                            };

                            if (proximoValor.Equals("1"))
                            {
                                resultado.Acertou = true;
                            }
                            else
                            {
                                resultado.Acertou = false;
                            }

                            resultados.Add(resultado);
                        }
                    }

                    int acertos = resultados.Count(x => x.Acertou);
                    int erros = resultados.Count(x => !x.Acertou);
                    int dif = acertos - erros;
                    int totApostas = acertos + erros;

                    rsPatterns.Add(new ResultadosPatterns(dif, acertos, erros, patternGerado, resultados, totApostas));
                }
            }

            return rsPatterns;
        }
    }
}
