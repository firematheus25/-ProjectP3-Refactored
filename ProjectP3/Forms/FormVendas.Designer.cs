
namespace ProjectP3
{
    partial class FormVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FuncionariosId = new ProjectP3.componentes.CmpBuscaCombinada();
            this.Funcionarios = new System.Windows.Forms.Label();
            this.DtVenda = new ProjectP3.componentes.CmpDataCalendario();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ValorVenda = new ProjectP3.componentes.CmpNumerico();
            this.label1 = new System.Windows.Forms.Label();
            this.PorcentagemVenda = new ProjectP3.componentes.CmpNumerico();
            this.VendasId = new System.Windows.Forms.TextBox();
            this.lblObrigaInfoMesmoMot = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Comissao = new ProjectP3.componentes.CmpNumerico();
            this.label6 = new System.Windows.Forms.Label();
            this.panelInferior.SuspendLayout();
            this.AlternaModo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Load)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(259, 15);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.Location = new System.Drawing.Point(340, 15);
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // panelInferior
            // 
            this.panelInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInferior.Location = new System.Drawing.Point(-2, 185);
            this.panelInferior.Size = new System.Drawing.Size(421, 49);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(279, 13);
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Retornar
            // 
            this.btn_Retornar.Location = new System.Drawing.Point(348, 12);
            // 
            // AlternaModo
            // 
            this.AlternaModo.Controls.Add(this.label6);
            this.AlternaModo.Controls.Add(this.Comissao);
            this.AlternaModo.Controls.Add(this.label5);
            this.AlternaModo.Controls.Add(this.label2);
            this.AlternaModo.Controls.Add(this.lblObrigaInfoMesmoMot);
            this.AlternaModo.Controls.Add(this.label3);
            this.AlternaModo.Controls.Add(this.label1);
            this.AlternaModo.Controls.Add(this.PorcentagemVenda);
            this.AlternaModo.Controls.Add(this.VendasId);
            this.AlternaModo.Controls.Add(this.ValorVenda);
            this.AlternaModo.Controls.Add(this.FuncionariosId);
            this.AlternaModo.Controls.Add(this.DtVenda);
            this.AlternaModo.Controls.Add(this.label4);
            this.AlternaModo.Controls.Add(this.Funcionarios);
            this.AlternaModo.Size = new System.Drawing.Size(421, 236);
            this.AlternaModo.Controls.SetChildIndex(this.Load, 0);
            this.AlternaModo.Controls.SetChildIndex(this.Funcionarios, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label4, 0);
            this.AlternaModo.Controls.SetChildIndex(this.DtVenda, 0);
            this.AlternaModo.Controls.SetChildIndex(this.FuncionariosId, 0);
            this.AlternaModo.Controls.SetChildIndex(this.ValorVenda, 0);
            this.AlternaModo.Controls.SetChildIndex(this.VendasId, 0);
            this.AlternaModo.Controls.SetChildIndex(this.panelInferior, 0);
            this.AlternaModo.Controls.SetChildIndex(this.PorcentagemVenda, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label1, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label3, 0);
            this.AlternaModo.Controls.SetChildIndex(this.lblObrigaInfoMesmoMot, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label2, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label5, 0);
            this.AlternaModo.Controls.SetChildIndex(this.Comissao, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label6, 0);
            // 
            // PalavraChave
            // 
            this.PalavraChave.Size = new System.Drawing.Size(178, 20);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(170, 74);
            // 
            // FuncionariosId
            // 
            this.FuncionariosId.BackColor = System.Drawing.Color.Transparent;
            this.FuncionariosId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FuncionariosId.CorFundo = System.Drawing.Color.Transparent;
            this.FuncionariosId.LarguraCodigo = 100;
            this.FuncionariosId.Location = new System.Drawing.Point(87, 15);
            this.FuncionariosId.Mascara = "";
            this.FuncionariosId.Name = "FuncionariosId";
            this.FuncionariosId.Size = new System.Drawing.Size(299, 21);
            this.FuncionariosId.TabIndex = 1;
            this.FuncionariosId.ConsultarAPI += new ProjectP3.componentes.CmpBuscaCombinada.EventHandlerCustom(this.FuncionariosId_ConsultarAPI);
            this.FuncionariosId.ConsultarClick += new System.EventHandler(this.FuncionariosId_ConsultarClick);
            // 
            // Funcionarios
            // 
            this.Funcionarios.AutoSize = true;
            this.Funcionarios.Location = new System.Drawing.Point(10, 19);
            this.Funcionarios.Name = "Funcionarios";
            this.Funcionarios.Size = new System.Drawing.Size(65, 13);
            this.Funcionarios.TabIndex = 2;
            this.Funcionarios.Text = "Funcionário:";
            // 
            // DtVenda
            // 
            this.DtVenda.BackColor = System.Drawing.SystemColors.Control;
            this.DtVenda.CorFundo = System.Drawing.SystemColors.Control;
            this.DtVenda.DataMaxima = new System.DateTime(2109, 12, 31, 0, 0, 0, 0);
            this.DtVenda.DataMinima = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DtVenda.Date = null;
            this.DtVenda.formatoCompetencia = false;
            this.DtVenda.Location = new System.Drawing.Point(87, 42);
            this.DtVenda.Name = "DtVenda";
            this.DtVenda.Size = new System.Drawing.Size(101, 21);
            this.DtVenda.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "R$:";
            // 
            // ValorVenda
            // 
            this.ValorVenda.CasasDecimais = 2;
            this.ValorVenda.Location = new System.Drawing.Point(88, 69);
            this.ValorVenda.Name = "ValorVenda";
            this.ValorVenda.Size = new System.Drawing.Size(100, 20);
            this.ValorVenda.TabIndex = 6;
            this.ValorVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ValorVenda.Valor = null;
            this.ValorVenda.ValorMaximo = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.ValorVenda.TextChanged += new System.EventHandler(this.ValorVenda_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Porcentagem:";
            // 
            // PorcentagemVenda
            // 
            this.PorcentagemVenda.CasasDecimais = 2;
            this.PorcentagemVenda.Enabled = false;
            this.PorcentagemVenda.Location = new System.Drawing.Point(88, 95);
            this.PorcentagemVenda.Name = "PorcentagemVenda";
            this.PorcentagemVenda.Size = new System.Drawing.Size(100, 20);
            this.PorcentagemVenda.TabIndex = 8;
            this.PorcentagemVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PorcentagemVenda.Valor = null;
            this.PorcentagemVenda.ValorMaximo = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            // 
            // VendasId
            // 
            this.VendasId.Location = new System.Drawing.Point(314, 159);
            this.VendasId.Name = "VendasId";
            this.VendasId.Size = new System.Drawing.Size(100, 20);
            this.VendasId.TabIndex = 9;
            this.VendasId.Visible = false;
            // 
            // lblObrigaInfoMesmoMot
            // 
            this.lblObrigaInfoMesmoMot.AutoSize = true;
            this.lblObrigaInfoMesmoMot.BackColor = System.Drawing.SystemColors.Control;
            this.lblObrigaInfoMesmoMot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObrigaInfoMesmoMot.ForeColor = System.Drawing.Color.Maroon;
            this.lblObrigaInfoMesmoMot.Location = new System.Drawing.Point(194, 46);
            this.lblObrigaInfoMesmoMot.Name = "lblObrigaInfoMesmoMot";
            this.lblObrigaInfoMesmoMot.Size = new System.Drawing.Size(17, 13);
            this.lblObrigaInfoMesmoMot.TabIndex = 131;
            this.lblObrigaInfoMesmoMot.Text = "(*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(390, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "(*)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(194, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 133;
            this.label5.Text = "(*)";
            // 
            // Comissao
            // 
            this.Comissao.CasasDecimais = 2;
            this.Comissao.Enabled = false;
            this.Comissao.Location = new System.Drawing.Point(88, 121);
            this.Comissao.Name = "Comissao";
            this.Comissao.Size = new System.Drawing.Size(100, 20);
            this.Comissao.TabIndex = 134;
            this.Comissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Comissao.Valor = null;
            this.Comissao.ValorMaximo = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 135;
            this.label6.Text = "Comissão:";
            // 
            // FormVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 236);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormVendas";
            this.Text = "Vendas";
            this.panelInferior.ResumeLayout(false);
            this.AlternaModo.ResumeLayout(false);
            this.AlternaModo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Load)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Funcionarios;
        private componentes.CmpDataCalendario DtVenda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private componentes.CmpNumerico ValorVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox VendasId;
        public componentes.CmpBuscaCombinada FuncionariosId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblObrigaInfoMesmoMot;
        private System.Windows.Forms.Label label6;
        private componentes.CmpNumerico Comissao;
        public componentes.CmpNumerico PorcentagemVenda;
    }
}