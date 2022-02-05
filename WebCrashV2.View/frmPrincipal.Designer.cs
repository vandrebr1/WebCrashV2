
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.btnCrash = new System.Windows.Forms.Button();
            this.txtValorAposta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMultiplicador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnalisarResultados = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbrirNavegador
            // 
            this.btnAbrirNavegador.Enabled = false;
            this.btnAbrirNavegador.Location = new System.Drawing.Point(12, 28);
            this.btnAbrirNavegador.Name = "btnAbrirNavegador";
            this.btnAbrirNavegador.Size = new System.Drawing.Size(169, 23);
            this.btnAbrirNavegador.TabIndex = 0;
            this.btnAbrirNavegador.Text = "Abrir Navegador";
            this.btnAbrirNavegador.UseVisualStyleBackColor = true;
            this.btnAbrirNavegador.Click += new System.EventHandler(this.btnAbrirNavegador_Click);
            // 
            // btnCapturarInformacao
            // 
            this.btnCapturarInformacao.Location = new System.Drawing.Point(10, 61);
            this.btnCapturarInformacao.Name = "btnCapturarInformacao";
            this.btnCapturarInformacao.Size = new System.Drawing.Size(171, 23);
            this.btnCapturarInformacao.TabIndex = 1;
            this.btnCapturarInformacao.Text = "Capturar Informacao";
            this.btnCapturarInformacao.UseVisualStyleBackColor = true;
            this.btnCapturarInformacao.Click += new System.EventHandler(this.btnCapturarInformacao_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAnalisarResultados);
            this.groupBox1.Controls.Add(this.btnCapturarInformacao);
            this.groupBox1.Controls.Add(this.btnAbrirNavegador);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 133);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Testes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPattern);
            this.groupBox2.Controls.Add(this.btnCrash);
            this.groupBox2.Controls.Add(this.txtValorAposta);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtMultiplicador);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 150);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automação";
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(80, 30);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(100, 20);
            this.txtPattern.TabIndex = 18;
            this.txtPattern.Text = "11";
            // 
            // btnCrash
            // 
            this.btnCrash.Location = new System.Drawing.Point(91, 108);
            this.btnCrash.Name = "btnCrash";
            this.btnCrash.Size = new System.Drawing.Size(89, 23);
            this.btnCrash.TabIndex = 17;
            this.btnCrash.Text = "Crash";
            this.btnCrash.UseVisualStyleBackColor = true;
            this.btnCrash.Click += new System.EventHandler(this.btnCrash_Click);
            // 
            // txtValorAposta
            // 
            this.txtValorAposta.Location = new System.Drawing.Point(80, 82);
            this.txtValorAposta.Name = "txtValorAposta";
            this.txtValorAposta.Size = new System.Drawing.Size(100, 20);
            this.txtValorAposta.TabIndex = 16;
            this.txtValorAposta.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Valor Aposta";
            // 
            // txtMultiplicador
            // 
            this.txtMultiplicador.Location = new System.Drawing.Point(80, 56);
            this.txtMultiplicador.Name = "txtMultiplicador";
            this.txtMultiplicador.Size = new System.Drawing.Size(100, 20);
            this.txtMultiplicador.TabIndex = 14;
            this.txtMultiplicador.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Multiplicador";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Pattern";
            // 
            // btnAnalisarResultados
            // 
            this.btnAnalisarResultados.Location = new System.Drawing.Point(10, 94);
            this.btnAnalisarResultados.Name = "btnAnalisarResultados";
            this.btnAnalisarResultados.Size = new System.Drawing.Size(171, 23);
            this.btnAnalisarResultados.TabIndex = 2;
            this.btnAnalisarResultados.Text = "Procurar Padrões";
            this.btnAnalisarResultados.UseVisualStyleBackColor = true;
            this.btnAnalisarResultados.Click += new System.EventHandler(this.btnAnalisarResultados_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 316);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirNavegador;
        private System.Windows.Forms.Button btnCapturarInformacao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCrash;
        private System.Windows.Forms.TextBox txtValorAposta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMultiplicador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Button btnAnalisarResultados;
    }
}

