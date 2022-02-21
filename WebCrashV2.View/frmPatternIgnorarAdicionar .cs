using System;
using System.Windows.Forms;
using WebCrashV2.LIB.Infraestrutura.Modelos;
using WebCrashV2.LIB.Repository.DB;

namespace WebCrashV2.View
{
    public partial class frmPatternIgnorarAdicionar : Form
    {
        public frmPatternIgnorarAdicionar()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var repo = new PatternsIgnorarRepository(new DBSession());
            var patternIgnorar = new PatternsIgnorar(0, txtPatternIgnorar.Text.Trim());
            repo.Salvar(patternIgnorar);
            Close();
        }
    }
}
