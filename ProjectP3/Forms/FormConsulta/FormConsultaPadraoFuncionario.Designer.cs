
namespace ProjectP3.Forms.FormConsulta
{
    partial class FormConsultaPadraoFuncionario
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
            this.SuspendLayout();
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            this.GridConsulta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridConsulta_CellDoubleClick);
            // 
            // ConsultaFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 450);
            this.Name = "ConsultaFuncionario";
            this.Text = "Consulta Funcionário";
            this.Load += new System.EventHandler(this.ConsultaFuncionario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}