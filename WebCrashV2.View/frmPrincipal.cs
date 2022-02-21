using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
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
        private IEnumerable<PatternsJogar> patternsJogar;
        private IEnumerable<PatternsIgnorar> patternsIgnorar;
        private Navegador Navegador;

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

            CarregarPatternsIgnorar();
        }

        private void CarregarPatternsIgnorar()
        {
            var patternsIgnorarRepo = new PatternsIgnorarRepository(new DBSession());
            patternsIgnorar = patternsIgnorarRepo.SelecionarTodos();
            PopularTabelaPatternsIgnorar(patternsIgnorar);
        }

        private void PopularTabelaPatternsIgnorar(IEnumerable<PatternsIgnorar> patternsIgnorar)
        {
            var data = patternsIgnorar.ToList();
            dgPatternsIgnorar.DataSource = data;
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
                txtQtdNegativaParar.Text = ultConfig.QtdNegativasParar.ToString();
                txtQtdPositivaParar.Text = ultConfig.QtdPositivasParar.ToString();
            }

        }

        private Configuracoes SalvarConfiguracoes(double multiplicador, double valorAposta, bool apostarPraValer,
                                         int qtdNegativasParar, int qtdPositivasParar)
        {
            var configRepo = new ConfiguracoesRepository(new DBSession());
            var config = new Configuracoes(0, multiplicador, valorAposta, apostarPraValer, qtdNegativasParar, qtdPositivasParar);
            configRepo.Salvar(config);

            return config;

        }

        private void btnAbrirNavegador_Click(object sender, EventArgs e)
        {
            var webCaptureService = new Navegador();
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
            List<string> patternsIgn = patternsIgnorar.Select(e => e.PatternIgnorar).ToList();

            double multiplicador = Convert.ToDouble(txtMultiplicador.Text, new CultureInfo("pt-BR"));
            double valorAposta = Convert.ToDouble(txtValorAposta.Text, new CultureInfo("pt-BR"));
            bool apostarPraValer = chkApostarPraValer.Checked && chkApostarPraValer.Enabled;
            int qtdNegativasParar = Convert.ToInt32(txtQtdNegativaParar.Text);
            int qtdPositivasParar = Convert.ToInt32(txtQtdPositivaParar.Text);

            var configuracoes = SalvarConfiguracoes(multiplicador, valorAposta, apostarPraValer,
                                qtdNegativasParar, qtdPositivasParar);

            var roboCrash = new RoboCrash(configuracoes, patterns, patternsIgn);

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
            Navegador = Navegador.GetInstance();

            var jogoCaptura = new JogoStatusService();

            Navegador.AbrirNavegador();

            while (!jogoCaptura.UsuarioLogado())
            {
                lblUsuario.Text = "Aguardando usuário logar!";
                Thread.Sleep(1000);
            }

            lblUsuario.Text = "Logado!";
            btnAbrirELogar.Enabled = false;
            btnCrash.Enabled = true;
            chkApostarPraValer.Enabled = true;
        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            var repo = new PatternsJogarRepository(new DBSession());
            repo.Apagar(RegistroSelecionadoPatternJogar());
            CarregarPatternsJogar();
        }

        private PatternsJogar RegistroSelecionadoPatternJogar()
        {
            return (PatternsJogar)dgPatternsJogar.CurrentRow.DataBoundItem;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            new frmPatternJogarAdicionar().ShowDialog();
            CarregarPatternsJogar();
        }

        private void btnAdicionarIgnorar_Click(object sender, EventArgs e)
        {
            new frmPatternIgnorarAdicionar().ShowDialog();
            CarregarPatternsIgnorar();
        }

        private void btnDesativarIgnorar_Click(object sender, EventArgs e)
        {
            var repo = new PatternsIgnorarRepository(new DBSession());
            repo.Apagar(RegistroSelecionadoPatternIgnorar());
            CarregarPatternsIgnorar();
        }

        private PatternsIgnorar RegistroSelecionadoPatternIgnorar()
        {
            return (PatternsIgnorar)dgPatternsIgnorar.CurrentRow.DataBoundItem;
        }
    }
}
