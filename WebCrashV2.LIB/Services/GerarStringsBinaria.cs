using System.Collections.Generic;

namespace WebCrashV2.LIB.Services
{
    public class GerarStringsBinaria
    {
        public GerarStringsBinaria(int posicoes)
        {
            StringsBinaria = new List<string>();
            int[] arr = new int[posicoes];
            generateAllBinaryStrings(posicoes, arr, 0);
        }

        public List<string> StringsBinaria { get; set; }

        private void AddLista(int[] arr, int n)
        {
            var bin = "";
            for (int i = 0; i < n; i++)
            {
                bin += arr[i].ToString();
            }
            StringsBinaria.Add(bin);
        }

        private void generateAllBinaryStrings(int n,
                                    int[] arr, int i)
        {
            if (i == n)
            {
                AddLista(arr, n);
                return;
            }


            arr[i] = 0;
            generateAllBinaryStrings(n, arr, i + 1);


            arr[i] = 1;
            generateAllBinaryStrings(n, arr, i + 1);
        }
    }
}
