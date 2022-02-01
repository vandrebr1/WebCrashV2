using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.LIB.Observable
{
    public interface IJogoSubject
    {
        void AttachRobo(IRoboObserver observer);

        void Detach(IRoboObserver observer);

        void IsApostar();

        void IsObterPremio(NavegadorService navegador);

        void FinalizaAposta();
    }
}
