using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCrashV2.LIB.Domain.Robo;
using WebCrashV2.LIB.Domain.WebJogo;
using WebCrashV2.LIB.Infraestrutura.Modelos;
using WebCrashV2.LIB.Repository.DB;
using WebCrashV2.LIB.Services;

namespace WebCrashV2.View
{
    public partial class frmPrincipal : Form
    {
        IEnumerable<PatternsJogar> patternsJogar;
        public frmPrincipal()
        {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("_webcrash.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            CarregarConfiguracoes();
            CarregarPatternsJogar();
        }

        private void CarregarPatternsJogar()
        {
            var patternsJogarRepo = new PatternsJogarRepository(new DBSession());
            patternsJogar = patternsJogarRepo.SelecionarTodos();
            PopularTabelaPatternsJogar(patternsJogar);
        }

        private void PopularTabelaPatternsJogar(IEnumerable<PatternsJogar> patternsJogar)
        {
            var data = patternsJogar.ToList();
            dgPatternsJogar.DataSource = data;
        }

        private void CarregarConfiguracoes()
        {
            var configRepo = new ConfiguracoesRepository(new DBSession());
            var ultConfig = configRepo.GetUltimaConfiguracao();
            if (ultConfig != null)
            {
                txtValorAposta.Text = ultConfig.ValorAposta.ToString();
                txtMultiplicador.Text = ultConfig.Multiplicador.ToString();
                chkApostarPraValer.Checked = ultConfig.ApostarPraValer;
            }

        }

        private void SalvarConfiguracoes(double multiplicador, double valorAposta, bool apostarPraValer)
        {
            var configRepo = new ConfiguracoesRepository(new DBSession());
            var config = new Configuracoes(0, multiplicador, valorAposta, apostarPraValer);
            configRepo.Salvar(config);
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

        private void btnCrash_Click(object sender, EventArgs e)
        {
            btnAbrirELogar.Enabled = false;
            Crash();
        }

        private void Crash()
        {
            List<string> patterns = patternsJogar.Select(e => e.Pattern).ToList();

            double multiplicador = Convert.ToDouble(txtMultiplicador.Text, new CultureInfo("pt-BR"));
            double valorAposta = Convert.ToDouble(txtValorAposta.Text, new CultureInfo("pt-BR"));
            bool apostarPraValer = chkApostarPraValer.Checked;

            SalvarConfiguracoes(multiplicador, valorAposta, apostarPraValer);

            var roboCrash = new RoboCrash(patterns, multiplicador, valorAposta);

            var jogoControlador = new JogoControlador();
            jogoControlador.AttachRobo(roboCrash);

            jogoControlador.Iniciar();
        }

        private void btnAnalisarResultados_Click(object sender, EventArgs e)
        {
            new frmProcurarPadrao().Show();
        }

        private void btnAbrirELogar_Click(object sender, EventArgs e)
        {
            btnCrash.Enabled = false;

            var navegador = new NavegadorService();
            var jogoCaptura = new JogoStatusService(navegador);

            navegador.AbrirNavegador();

            while (!jogoCaptura.UsuarioLogado())
            {
                lblUsuario.Text = "Aguardando usuário logar!";
                Thread.Sleep(1000);
            }

            lblUsuario.Text = "Logado!";
            btnAbrirELogar.Enabled = false;
            btnCrash.Enabled = true;


        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            var repo = new PatternsJogarRepository(new DBSession());
            repo.Apagar(RegistroSelecionado());
            CarregarPatternsJogar();
        }

        private PatternsJogar RegistroSelecionado()
        {
            return (PatternsJogar)dgPatternsJogar.CurrentRow.DataBoundItem;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            new frmPatternJogarAdicionar().ShowDialog();
            CarregarPatternsJogar();
        }
    }
}
