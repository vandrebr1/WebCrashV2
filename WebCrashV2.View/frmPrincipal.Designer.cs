
namespace WebCrashV2.View
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAbrirNavegador = new System.Windows.Forms.Button();
            this.btnCapturarInformacao = new System.Windows.Forms.Button();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAbrirNavegador
            // 
            this.btnAbrirNavegador.Location = new System.Drawing.Point(12, 12);
            this.btnAbrirNavegador.Name = "btnAbrirNavegador";
            this.btnAbrirNavegador.Size = new System.Drawing.Size(140, 23);
            this.btnAbrirNavegador.TabIndex = 0;
            this.btnAbrirNavegador.Text = "Abrir Navegador";
            this.btnAbrirNavegador.UseVisualStyleBackColor = true;
            this.btnAbrirNavegador.Click += new System.EventHandler(this.btnAbrirNavegador_Click);
            // 
            // btnCapturarInformacao
            // 
            this.btnCapturarInformacao.Location = new System.Drawing.Point(12, 41);
            this.btnCapturarInformacao.Name = "btnCapturarInformacao";
            this.btnCapturarInformacao.Size = new System.Drawing.Size(140, 23);
            this.btnCapturarInformacao.TabIndex = 1;
            this.btnCapturarInformacao.Text = "Capturar Informacao";
            this.btnCapturarInformacao.UseVisualStyleBackColor = true;
            this.btnCapturarInformacao.Click += new System.EventHandler(this.btnCapturarInformacao_Click);
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(372, 12);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(416, 426);
            this.txtLogs.TabIndex = 2;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.btnCapturarInformacao);
            this.Controls.Add(this.btnAbrirNavegador);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirNavegador;
        private System.Windows.Forms.Button btnCapturarInformacao;
        private System.Windows.Forms.TextBox txtLogs;
    }
}

