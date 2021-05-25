
namespace ProjectP3
{
    partial class FormRegistroPonto
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
            this.RegistroPontoId = new System.Windows.Forms.TextBox();
            this.FuncionariosId = new ProjectP3.componentes.CmpBuscaCombinada();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DtPonto = new ProjectP3.componentes.CmpDataCalendario();
            this.Entrada = new System.Windows.Forms.DateTimePicker();
            this.Saida = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.Horas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblObrigaInfoMesmoMot = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelInferior.SuspendLayout();
            this.AlternaModo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Load)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(258, 14);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.Location = new System.Drawing.Point(339, 14);
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(11, 14);
            // 
            // panelInferior
            // 
            this.panelInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInferior.Location = new System.Drawing.Point(-2, 183);
            this.panelInferior.Size = new System.Drawing.Size(421, 51);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(279, 13);
            this.btn_Buscar.Size = new System.Drawing.Size(69, 23);
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Retornar
            // 
            this.btn_Retornar.Location = new System.Drawing.Point(354, 13);
            this.btn_Retornar.Size = new System.Drawing.Size(58, 23);
            // 
            // AlternaModo
            // 
            this.AlternaModo.Controls.Add(this.label9);
            this.AlternaModo.Controls.Add(this.label8);
            this.AlternaModo.Controls.Add(this.label7);
            this.AlternaModo.Controls.Add(this.lblObrigaInfoMesmoMot);
            this.AlternaModo.Controls.Add(this.label6);
            this.AlternaModo.Controls.Add(this.label3);
            this.AlternaModo.Controls.Add(this.label4);
            this.AlternaModo.Controls.Add(this.Saida);
            this.AlternaModo.Controls.Add(this.Entrada);
            this.AlternaModo.Controls.Add(this.Horas);
            this.AlternaModo.Controls.Add(this.DtPonto);
            this.AlternaModo.Controls.Add(this.label5);
            this.AlternaModo.Controls.Add(this.label2);
            this.AlternaModo.Controls.Add(this.RegistroPontoId);
            this.AlternaModo.Controls.Add(this.FuncionariosId);
            this.AlternaModo.Size = new System.Drawing.Size(421, 236);
            this.AlternaModo.Controls.SetChildIndex(this.Load, 0);
            this.AlternaModo.Controls.SetChildIndex(this.FuncionariosId, 0);
            this.AlternaModo.Controls.SetChildIndex(this.RegistroPontoId, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label2, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label5, 0);
            this.AlternaModo.Controls.SetChildIndex(this.DtPonto, 0);
            this.AlternaModo.Controls.SetChildIndex(this.Horas, 0);
            this.AlternaModo.Controls.SetChildIndex(this.Entrada, 0);
            this.AlternaModo.Controls.SetChildIndex(this.panelInferior, 0);
            this.AlternaModo.Controls.SetChildIndex(this.Saida, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label4, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label3, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label6, 0);
            this.AlternaModo.Controls.SetChildIndex(this.lblObrigaInfoMesmoMot, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label7, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label8, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label9, 0);
            // 
            // PalavraChave
            // 
            this.PalavraChave.Location = new System.Drawing.Point(95, 15);
            this.PalavraChave.Size = new System.Drawing.Size(178, 20);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(187, 82);
            // 
            // RegistroPontoId
            // 
            this.RegistroPontoId.Location = new System.Drawing.Point(314, 157);
            this.RegistroPontoId.Name = "RegistroPontoId";
            this.RegistroPontoId.Size = new System.Drawing.Size(100, 20);
            this.RegistroPontoId.TabIndex = 1;
            this.RegistroPontoId.Visible = false;
            // 
            // FuncionariosId
            // 
            this.FuncionariosId.BackColor = System.Drawing.Color.Transparent;
            this.FuncionariosId.BackgroundImage = global::ProjectP3.Properties.Resources.magnifier;
            this.FuncionariosId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FuncionariosId.CorFundo = System.Drawing.Color.Transparent;
            this.FuncionariosId.LarguraCodigo = 100;
            this.FuncionariosId.Location = new System.Drawing.Point(78, 27);
            this.FuncionariosId.Mascara = "";
            this.FuncionariosId.Name = "FuncionariosId";
            this.FuncionariosId.Size = new System.Drawing.Size(313, 21);
            this.FuncionariosId.TabIndex = 3;
            this.FuncionariosId.ConsultarAPI += new ProjectP3.componentes.CmpBuscaCombinada.EventHandlerCustom(this.FuncionariosId_ConsultarAPI);
            this.FuncionariosId.ConsultarClick += new System.EventHandler(this.FuncionariosId_ConsultarClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Saída:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Entrada:";
            // 
            // DtPonto
            // 
            this.DtPonto.BackColor = System.Drawing.SystemColors.Control;
            this.DtPonto.CorFundo = System.Drawing.SystemColors.Control;
            this.DtPonto.DataMaxima = new System.DateTime(2110, 12, 31, 0, 0, 0, 0);
            this.DtPonto.DataMinima = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DtPonto.Date = null;
            this.DtPonto.formatoCompetencia = false;
            this.DtPonto.Location = new System.Drawing.Point(77, 54);
            this.DtPonto.Name = "DtPonto";
            this.DtPonto.Size = new System.Drawing.Size(101, 21);
            this.DtPonto.TabIndex = 8;
            // 
            // Entrada
            // 
            this.Entrada.CustomFormat = "HH:mm:00";
            this.Entrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Entrada.Location = new System.Drawing.Point(77, 81);
            this.Entrada.Name = "Entrada";
            this.Entrada.ShowUpDown = true;
            this.Entrada.Size = new System.Drawing.Size(101, 20);
            this.Entrada.TabIndex = 9;
            // 
            // Saida
            // 
            this.Saida.CustomFormat = "HH:mm:00";
            this.Saida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Saida.Location = new System.Drawing.Point(77, 107);
            this.Saida.Name = "Saida";
            this.Saida.ShowUpDown = true;
            this.Saida.Size = new System.Drawing.Size(101, 20);
            this.Saida.TabIndex = 10;
            this.Saida.ValueChanged += new System.EventHandler(this.Saida_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Horas:";
            // 
            // Horas
            // 
            this.Horas.Enabled = false;
            this.Horas.Location = new System.Drawing.Point(77, 133);
            this.Horas.Name = "Horas";
            this.Horas.Size = new System.Drawing.Size(100, 20);
            this.Horas.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Funcionário";
            // 
            // lblObrigaInfoMesmoMot
            // 
            this.lblObrigaInfoMesmoMot.AutoSize = true;
            this.lblObrigaInfoMesmoMot.BackColor = System.Drawing.SystemColors.Control;
            this.lblObrigaInfoMesmoMot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObrigaInfoMesmoMot.ForeColor = System.Drawing.Color.Maroon;
            this.lblObrigaInfoMesmoMot.Location = new System.Drawing.Point(184, 110);
            this.lblObrigaInfoMesmoMot.Name = "lblObrigaInfoMesmoMot";
            this.lblObrigaInfoMesmoMot.Size = new System.Drawing.Size(17, 13);
            this.lblObrigaInfoMesmoMot.TabIndex = 131;
            this.lblObrigaInfoMesmoMot.Text = "(*)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(184, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 132;
            this.label7.Text = "(*)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(184, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 133;
            this.label8.Text = "(*)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(397, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 134;
            this.label9.Text = "(*)";
            // 
            // FormRegistroPonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 236);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormRegistroPonto";
            this.Text = "Registro de Ponto";
            this.panelInferior.ResumeLayout(false);
            this.AlternaModo.ResumeLayout(false);
            this.AlternaModo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Load)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RegistroPontoId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private componentes.CmpDataCalendario DtPonto;
        private System.Windows.Forms.DateTimePicker Entrada;
        private System.Windows.Forms.DateTimePicker Saida;
        private System.Windows.Forms.TextBox Horas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public componentes.CmpBuscaCombinada FuncionariosId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblObrigaInfoMesmoMot;
    }
}