
namespace ProjectP3.MDI
{
    partial class FormConsult
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
            this.GridConsulta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // GridConsulta
            // 
            this.GridConsulta.AllowUserToAddRows = false;
            this.GridConsulta.AllowUserToDeleteRows = false;
            this.GridConsulta.AllowUserToResizeRows = false;
            this.GridConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridConsulta.Location = new System.Drawing.Point(12, 12);
            this.GridConsulta.Name = "GridConsulta";
            this.GridConsulta.RowHeadersVisible = false;
            this.GridConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridConsulta.ShowEditingIcon = false;
            this.GridConsulta.Size = new System.Drawing.Size(292, 426);
            this.GridConsulta.TabIndex = 2;
            this.GridConsulta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridConsulta_CellDoubleClick);
            // 
            // FormConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 450);
            this.Controls.Add(this.GridConsulta);
            this.Name = "FormConsulta";
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.FormConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridConsulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView GridConsulta;
    }
}