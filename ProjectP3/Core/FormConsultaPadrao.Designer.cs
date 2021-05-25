
namespace ProjectP3.MDI
{
    partial class FormConsultaPadrao
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
            this.PalavraChave = new System.Windows.Forms.TextBox();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GridConsulta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // PalavraChave
            // 
            this.PalavraChave.Location = new System.Drawing.Point(98, 27);
            this.PalavraChave.Name = "PalavraChave";
            this.PalavraChave.Size = new System.Drawing.Size(273, 20);
            this.PalavraChave.TabIndex = 1;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(377, 25);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Buscar.TabIndex = 2;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Palavra-Chave:";
            // 
            // GridConsulta
            // 
            this.GridConsulta.AllowUserToAddRows = false;
            this.GridConsulta.AllowUserToDeleteRows = false;
            this.GridConsulta.AllowUserToResizeRows = false;
            this.GridConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridConsulta.Location = new System.Drawing.Point(12, 54);
            this.GridConsulta.Name = "GridConsulta";
            this.GridConsulta.RowHeadersVisible = false;
            this.GridConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridConsulta.ShowEditingIcon = false;
            this.GridConsulta.Size = new System.Drawing.Size(440, 384);
            this.GridConsulta.TabIndex = 4;
            this.GridConsulta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridConsulta_CellDoubleClick);
            // 
            // FormConsultaPadrao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 450);
            this.Controls.Add(this.GridConsulta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.PalavraChave);
            this.Name = "FormConsultaPadrao";
            this.Text = "FormConsultaPadrao";
            this.Load += new System.EventHandler(this.FormConsultaPadrao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox PalavraChave;
        protected System.Windows.Forms.Button Btn_Buscar;
        public System.Windows.Forms.DataGridView GridConsulta;
    }
}