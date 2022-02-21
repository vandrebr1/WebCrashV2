using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.LIB.Observable
{
    public interface IRoboObserver
    {
        void RoboIsApostar();
        void ObterPremio(IWebElement crashGameCounter);
        void FinalizaAposta(double multiplicadorFinalizado);
        void ForcarReceberPremio();
    }
}
