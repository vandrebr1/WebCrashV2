using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCrashV2.LIB.Domain.WebJogo;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.View
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("_webcrash.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private void btnAbrirNavegador_Click(object sender, EventArgs e)
        {
            var webCaptureService = new NavegadorService();
            webCaptureService.AbrirNavegador();
        }

        private void btnCapturarInformacao_Click(object sender, EventArgs e)
        {
            var jogoControlador = new JogoControlador();
            jogoControlador.Iniciar();

        }
    }
}
