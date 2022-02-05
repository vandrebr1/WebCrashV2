using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCrashV2.LIB.Domain.ProcurarPadrao;
using WebCrashV2.LIB.Infraestrutura.Interfaces;
using WebCrashV2.LIB.Infraestrutura.Modelos;
using WebCrashV2.LIB.Repository.DB;

namespace WebCrashV2.View
{
    public partial class frmProcurarPadrao : Form
    {
        public frmProcurarPadrao()
        {
            InitializeComponent();
        }

        private void rbIntervaloDias_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmProcurarPadrao_Load(object sender, EventArgs e)
        {
            InicializaCampos();
        }

        private void InicializaCampos()
        {
            rbIntervaloDiasAgrupadoHoras.Checked = true;
            rbTodos.Checked = true;
        }

        private void btnCrash_Click(object sender, EventArgs e)
        {
            IConfiguracaoAnalise analise = RetornarAnalise();
            var configuracoesProcurarPadrao = RetornarConfiguracoesProcurarPadrao();
            var resultados = analise.Iniciar(configuracoesProcurarPadrao);

            SalvarAnalise(resultados, configuracoesProcurarPadrao, analise);
        }

        private ConfiguracoesProcurarPadrao RetornarConfiguracoesProcurarPadrao()
        {
            var multAnalisado = Convert.ToDouble(txtMultiplicadorAnalisado.Text);
            var qtdCaracteres = Convert.ToInt32(txtQtdCaracteresPatterns.Text);
            var apostaCalcular = Convert.ToDouble(txtValorApostaCalcular.Text);

            return new ConfiguracoesProcurarPadrao(qtdCaracteres, multAnalisado, apostaCalcular);

        }

        private void SalvarAnalise(List<ResultadosPatterns> resultados, ConfiguracoesProcurarPadrao configuracoesProcurarPadrao, IConfiguracaoAnalise ConfigAnalise)
        {
            var analisesRepo = new AnalisesRepository(new DBSession());

            double valorAposta = configuracoesProcurarPadrao.ValorApostaCalcular;
            double apostadoEm = configuracoesProcurarPadrao.MultiplicadorAnalisado;

            var ordenados = resultados.Where(x => x.TotalApostas > 0);

            var analise = new Analise();
            analise.DtAnalisado = DateTime.Now;

            analise.QuantidadeJogos = ConfigAnalise.QuantidadeJogos;
            analise.TipoAnalise = ConfigAnalise.Tipo;
            analise.DtDe = ConfigAnalise.DtDe;
            analise.DtAte = ConfigAnalise.DtAte;
            analise.HoraUnica = ConfigAnalise.HoraUnica;


            foreach (var ordenado in ordenados)
            {
                double ganhos = (apostadoEm * valorAposta * ordenado.QtdAcertos) - (ordenado.QtdAcertos * valorAposta) - (ordenado.QtdErros * valorAposta);

                analise.Pattern = ordenado.Pattern;
                analise.Diferenca = ordenado.Diferenca;
                analise.Acertos = ordenado.QtdAcertos;
                analise.Erros = ordenado.QtdErros;
                analise.TotalApostas = ordenado.TotalApostas;
                analise.Ganhos = ganhos;

                if (rbGanhosPositivos.Checked)
                {
                    if (ganhos > 0)
                    {
                        analisesRepo.Salvar(analise);
                    }
                }
                else
                {
                    analisesRepo.Salvar(analise);
                }
            }
        }

        private IConfiguracaoAnalise RetornarAnalise()
        {
            if (rbPeriodoInteiro.Checked)
            {
                return new AnaliseTodoPeriodo();
            }

            if (rbIntervaloDiasAgrupadoHoras.Checked)
            {
                return new AnaliseIntervaloDiasAgrupadoHora(dtpDiasAgrupadoHorasDe.Value, dtpDiasAgrupadoHorasAte.Value);
            }

            throw new NotImplementedException();
        }
    }
}
