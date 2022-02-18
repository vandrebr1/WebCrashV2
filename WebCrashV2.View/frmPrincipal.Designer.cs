
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
            this.btnAnalisarResultados = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.chkApostarPraValer = new System.Windows.Forms.CheckBox();
            this.btnAbrirELogar = new System.Windows.Forms.Button();
            this.btnCrash = new System.Windows.Forms.Button();
            this.txtValorAposta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMultiplicador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtQtdNegativaParar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQtdPositivaParar = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDesativarIgnorar = new System.Windows.Forms.Button();
            this.btnAdicionarIgnorar = new System.Windows.Forms.Button();
            this.dgPatternsIgnorar = new System.Windows.Forms.DataGridView();
            this.btnDesativar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dgPatternsJogar = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatternsIgnorar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatternsJogar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrirNavegador
            // 
            this.btnAbrirNavegador.Enabled = false;
            this.btnAbrirNavegador.Location = new System.Drawing.Point(14, 37);
            this.btnAbrirNavegador.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrirNavegador.Name = "btnAbrirNavegador";
            this.btnAbrirNavegador.Size = new System.Drawing.Size(198, 30);
            this.btnAbrirNavegador.TabIndex = 0;
            this.btnAbrirNavegador.Text = "Abrir Navegador";
            this.btnAbrirNavegador.UseVisualStyleBackColor = true;
            this.btnAbrirNavegador.Click += new System.EventHandler(this.btnAbrirNavegador_Click);
            // 
            // btnCapturarInformacao
            // 
            this.btnCapturarInformacao.Location = new System.Drawing.Point(11, 79);
            this.btnCapturarInformacao.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapturarInformacao.Name = "btnCapturarInformacao";
            this.btnCapturarInformacao.Size = new System.Drawing.Size(200, 30);
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
            this.groupBox1.Location = new System.Drawing.Point(717, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(226, 174);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Testes";
            // 
            // btnAnalisarResultados
            // 
            this.btnAnalisarResultados.Location = new System.Drawing.Point(11, 123);
            this.btnAnalisarResultados.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnalisarResultados.Name = "btnAnalisarResultados";
            this.btnAnalisarResultados.Size = new System.Drawing.Size(200, 30);
            this.btnAnalisarResultados.TabIndex = 2;
            this.btnAnalisarResultados.Text = "Procurar Padrões";
            this.btnAnalisarResultados.UseVisualStyleBackColor = true;
            this.btnAnalisarResultados.Click += new System.EventHandler(this.btnAnalisarResultados_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(11, 593);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(129, 17);
            this.lblUsuario.TabIndex = 21;
            this.lblUsuario.Text = "Usuário não logado!";
            // 
            // chkApostarPraValer
            // 
            this.chkApostarPraValer.AutoSize = true;
            this.chkApostarPraValer.Enabled = false;
            this.chkApostarPraValer.Location = new System.Drawing.Point(14, 40);
            this.chkApostarPraValer.Margin = new System.Windows.Forms.Padding(4);
            this.chkApostarPraValer.Name = "chkApostarPraValer";
            this.chkApostarPraValer.Size = new System.Drawing.Size(129, 21);
            this.chkApostarPraValer.TabIndex = 20;
            this.chkApostarPraValer.Text = "Apostar pra valer";
            this.chkApostarPraValer.UseVisualStyleBackColor = true;
            // 
            // btnAbrirELogar
            // 
            this.btnAbrirELogar.Location = new System.Drawing.Point(14, 546);
            this.btnAbrirELogar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrirELogar.Name = "btnAbrirELogar";
            this.btnAbrirELogar.Size = new System.Drawing.Size(126, 30);
            this.btnAbrirELogar.TabIndex = 19;
            this.btnAbrirELogar.Text = "Abrir para Logar";
            this.btnAbrirELogar.UseVisualStyleBackColor = true;
            this.btnAbrirELogar.Click += new System.EventHandler(this.btnAbrirELogar_Click);
            // 
            // btnCrash
            // 
            this.btnCrash.Location = new System.Drawing.Point(148, 546);
            this.btnCrash.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrash.Name = "btnCrash";
            this.btnCrash.Size = new System.Drawing.Size(86, 30);
            this.btnCrash.TabIndex = 17;
            this.btnCrash.Text = "Crash";
            this.btnCrash.UseVisualStyleBackColor = true;
            this.btnCrash.Click += new System.EventHandler(this.btnCrash_Click);
            // 
            // txtValorAposta
            // 
            this.txtValorAposta.Location = new System.Drawing.Point(101, 104);
            this.txtValorAposta.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorAposta.Name = "txtValorAposta";
            this.txtValorAposta.Size = new System.Drawing.Size(86, 25);
            this.txtValorAposta.TabIndex = 16;
            this.txtValorAposta.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Valor Aposta";
            // 
            // txtMultiplicador
            // 
            this.txtMultiplicador.Location = new System.Drawing.Point(101, 70);
            this.txtMultiplicador.Margin = new System.Windows.Forms.Padding(4);
            this.txtMultiplicador.Name = "txtMultiplicador";
            this.txtMultiplicador.Size = new System.Drawing.Size(86, 25);
            this.txtMultiplicador.TabIndex = 14;
            this.txtMultiplicador.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Multiplicador";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtQtdNegativaParar);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtQtdPositivaParar);
            this.groupBox3.Controls.Add(this.txtValorAposta);
            this.groupBox3.Controls.Add(this.chkApostarPraValer);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMultiplicador);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(14, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(695, 164);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configurações Sistema";
            // 
            // txtQtdNegativaParar
            // 
            this.txtQtdNegativaParar.Location = new System.Drawing.Point(330, 104);
            this.txtQtdNegativaParar.Margin = new System.Windows.Forms.Padding(4);
            this.txtQtdNegativaParar.Name = "txtQtdNegativaParar";
            this.txtQtdNegativaParar.Size = new System.Drawing.Size(86, 25);
            this.txtQtdNegativaParar.TabIndex = 24;
            this.txtQtdNegativaParar.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Qtd Negativas Parar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Qtd Positivas Parar";
            // 
            // txtQtdPositivaParar
            // 
            this.txtQtdPositivaParar.Location = new System.Drawing.Point(330, 70);
            this.txtQtdPositivaParar.Margin = new System.Windows.Forms.Padding(4);
            this.txtQtdPositivaParar.Name = "txtQtdPositivaParar";
            this.txtQtdPositivaParar.Size = new System.Drawing.Size(86, 25);
            this.txtQtdPositivaParar.TabIndex = 22;
            this.txtQtdPositivaParar.Text = "6";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDesativarIgnorar);
            this.groupBox4.Controls.Add(this.btnAdicionarIgnorar);
            this.groupBox4.Controls.Add(this.dgPatternsIgnorar);
            this.groupBox4.Controls.Add(this.btnDesativar);
            this.groupBox4.Controls.Add(this.btnAdicionar);
            this.groupBox4.Controls.Add(this.dgPatternsJogar);
            this.groupBox4.Location = new System.Drawing.Point(14, 187);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(929, 351);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Patterns Jogar";
            // 
            // btnDesativarIgnorar
            // 
            this.btnDesativarIgnorar.Location = new System.Drawing.Point(721, 31);
            this.btnDesativarIgnorar.Name = "btnDesativarIgnorar";
            this.btnDesativarIgnorar.Size = new System.Drawing.Size(86, 33);
            this.btnDesativarIgnorar.TabIndex = 28;
            this.btnDesativarIgnorar.Text = "Desativar";
            this.btnDesativarIgnorar.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarIgnorar
            // 
            this.btnAdicionarIgnorar.Location = new System.Drawing.Point(627, 31);
            this.btnAdicionarIgnorar.Name = "btnAdicionarIgnorar";
            this.btnAdicionarIgnorar.Size = new System.Drawing.Size(86, 33);
            this.btnAdicionarIgnorar.TabIndex = 27;
            this.btnAdicionarIgnorar.Text = "Adicionar";
            this.btnAdicionarIgnorar.UseVisualStyleBackColor = true;
            // 
            // dgPatternsIgnorar
            // 
            this.dgPatternsIgnorar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPatternsIgnorar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatternsIgnorar.Location = new System.Drawing.Point(627, 71);
            this.dgPatternsIgnorar.Margin = new System.Windows.Forms.Padding(4);
            this.dgPatternsIgnorar.Name = "dgPatternsIgnorar";
            this.dgPatternsIgnorar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatternsIgnorar.Size = new System.Drawing.Size(287, 272);
            this.dgPatternsIgnorar.TabIndex = 26;
            // 
            // btnDesativar
            // 
            this.btnDesativar.Location = new System.Drawing.Point(101, 31);
            this.btnDesativar.Name = "btnDesativar";
            this.btnDesativar.Size = new System.Drawing.Size(86, 33);
            this.btnDesativar.TabIndex = 25;
            this.btnDesativar.Text = "Desativar";
            this.btnDesativar.UseVisualStyleBackColor = true;
            this.btnDesativar.Click += new System.EventHandler(this.btnDesativar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(7, 31);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(86, 33);
            this.btnAdicionar.TabIndex = 24;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // dgPatternsJogar
            // 
            this.dgPatternsJogar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPatternsJogar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatternsJogar.Location = new System.Drawing.Point(8, 71);
            this.dgPatternsJogar.Margin = new System.Windows.Forms.Padding(4);
            this.dgPatternsJogar.Name = "dgPatternsJogar";
            this.dgPatternsJogar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatternsJogar.Size = new System.Drawing.Size(611, 272);
            this.dgPatternsJogar.TabIndex = 0;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 622);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAbrirELogar);
            this.Controls.Add(this.btnCrash);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatternsIgnorar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatternsJogar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirNavegador;
        private System.Windows.Forms.Button btnCapturarInformacao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCrash;
        private System.Windows.Forms.TextBox txtValorAposta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMultiplicador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnalisarResultados;
        private System.Windows.Forms.Button btnAbrirELogar;
        private System.Windows.Forms.CheckBox chkApostarPraValer;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgPatternsJogar;
        private System.Windows.Forms.Button btnDesativar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DataGridView dgPatternsIgnorar;
        private System.Windows.Forms.Button btnDesativarIgnorar;
        private System.Windows.Forms.Button btnAdicionarIgnorar;
        private System.Windows.Forms.TextBox txtQtdNegativaParar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQtdPositivaParar;
    }
}

