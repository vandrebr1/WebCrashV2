using System;
using System.Windows.Forms;
using WebCrashV2.LIB.Infraestrutura.Modelos;
using WebCrashV2.LIB.Repository.DB;

namespace WebCrashV2.View
{
    public partial class frmPatternJogarAdicionar : Form
    {
        public frmPatternJogarAdicionar()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var repo = new PatternsJogarRepository(new DBSession());
            var patternJogar = new PatternsJogar(0, txtPattern.Text.Trim(), true, DateTime.Now, false);
            repo.Salvar(patternJogar);
            Close();
        }
    }
}
