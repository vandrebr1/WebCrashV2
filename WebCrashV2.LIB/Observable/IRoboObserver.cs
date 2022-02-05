using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrashV2.LIB.Observable
{
    public interface IRoboObserver
    {
        void RoboIsApostar();
        void ObterPremio(Services.NavegadorService navegador);
        void FinalizaAposta(double multiplicadorFinalizado);

    }
}
