
namespace ProjectP3.Forms
{
    partial class FormSindicato
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
            this.label1 = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.TextBox();
            this.SindicatosId = new System.Windows.Forms.TextBox();
            this.lblObrigaInfoMesmoMot = new System.Windows.Forms.Label();
            this.panelInferior.SuspendLayout();
            this.AlternaModo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Load)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(222, 16);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(303, 16);
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // panelInferior
            // 
            this.panelInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInferior.Location = new System.Drawing.Point(-2, 139);
            this.panelInferior.Size = new System.Drawing.Size(391, 48);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(236, 12);
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Retornar
            // 
            this.btn_Retornar.Location = new System.Drawing.Point(316, 12);
            // 
            // AlternaModo
            // 
            this.AlternaModo.Controls.Add(this.lblObrigaInfoMesmoMot);
            this.AlternaModo.Controls.Add(this.SindicatosId);
            this.AlternaModo.Controls.Add(this.Nome);
            this.AlternaModo.Controls.Add(this.label1);
            this.AlternaModo.Size = new System.Drawing.Size(391, 190);
            this.AlternaModo.Controls.SetChildIndex(this.Load, 0);
            this.AlternaModo.Controls.SetChildIndex(this.panelInferior, 0);
            this.AlternaModo.Controls.SetChildIndex(this.label1, 0);
            this.AlternaModo.Controls.SetChildIndex(this.Nome, 0);
            this.AlternaModo.Controls.SetChildIndex(this.SindicatosId, 0);
            this.AlternaModo.Controls.SetChildIndex(this.lblObrigaInfoMesmoMot, 0);
            // 
            // PalavraChave
            // 
            this.PalavraChave.Size = new System.Drawing.Size(133, 20);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(170, 51);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sindicato:";
            // 
            // Nome
            // 
            this.Nome.Location = new System.Drawing.Point(70, 48);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(291, 20);
            this.Nome.TabIndex = 2;
            // 
            // SindicatosId
            // 
            this.SindicatosId.Location = new System.Drawing.Point(329, 113);
            this.SindicatosId.Name = "SindicatosId";
            this.SindicatosId.Size = new System.Drawing.Size(48, 20);
            this.SindicatosId.TabIndex = 3;
            this.SindicatosId.Visible = false;
            // 
            // lblObrigaInfoMesmoMot
            // 
            this.lblObrigaInfoMesmoMot.AutoSize = true;
            this.lblObrigaInfoMesmoMot.BackColor = System.Drawing.SystemColors.Control;
            this.lblObrigaInfoMesmoMot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObrigaInfoMesmoMot.ForeColor = System.Drawing.Color.Maroon;
            this.lblObrigaInfoMesmoMot.Location = new System.Drawing.Point(367, 51);
            this.lblObrigaInfoMesmoMot.Name = "lblObrigaInfoMesmoMot";
            this.lblObrigaInfoMesmoMot.Size = new System.Drawing.Size(17, 13);
            this.lblObrigaInfoMesmoMot.TabIndex = 131;
            this.lblObrigaInfoMesmoMot.Text = "(*)";
            // 
            // FormSindicato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 190);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormSindicato";
            this.Text = "Sindicatos";
            this.panelInferior.ResumeLayout(false);
            this.AlternaModo.ResumeLayout(false);
            this.AlternaModo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Load)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SindicatosId;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblObrigaInfoMesmoMot;
    }
}