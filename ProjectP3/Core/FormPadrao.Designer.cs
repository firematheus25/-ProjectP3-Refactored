
namespace ProjectP3
{
    partial class FormPadrao
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.btn_Excluir = new System.Windows.Forms.Button();
            this.GridConsultaP = new System.Windows.Forms.DataGridView();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.PalavraChave = new System.Windows.Forms.TextBox();
            this.lbl_palavrachave = new System.Windows.Forms.Label();
            this.btn_Retornar = new System.Windows.Forms.Button();
            this.AlternaModo = new System.Windows.Forms.Panel();
            this.Load = new System.Windows.Forms.PictureBox();
            this.panelInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsultaP)).BeginInit();
            this.AlternaModo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Load)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalvar.Location = new System.Drawing.Point(374, 15);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpar.Location = new System.Drawing.Point(455, 15);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 1;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(10, 15);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // panelInferior
            // 
            this.panelInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelInferior.Controls.Add(this.btn_Excluir);
            this.panelInferior.Controls.Add(this.btnConsultar);
            this.panelInferior.Controls.Add(this.btnLimpar);
            this.panelInferior.Controls.Add(this.btnSalvar);
            this.panelInferior.Location = new System.Drawing.Point(0, 402);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(544, 48);
            this.panelInferior.TabIndex = 0;
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.Location = new System.Drawing.Point(91, 15);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.Size = new System.Drawing.Size(75, 23);
            this.btn_Excluir.TabIndex = 3;
            this.btn_Excluir.Text = "Excluir";
            this.btn_Excluir.UseVisualStyleBackColor = true;
            this.btn_Excluir.Visible = false;
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // GridConsultaP
            // 
            this.GridConsultaP.AllowUserToAddRows = false;
            this.GridConsultaP.AllowUserToDeleteRows = false;
            this.GridConsultaP.AllowUserToResizeRows = false;
            this.GridConsultaP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridConsultaP.Location = new System.Drawing.Point(12, 41);
            this.GridConsultaP.Name = "GridConsultaP";
            this.GridConsultaP.RowHeadersVisible = false;
            this.GridConsultaP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridConsultaP.ShowEditingIcon = false;
            this.GridConsultaP.Size = new System.Drawing.Size(520, 397);
            this.GridConsultaP.TabIndex = 3;
            this.GridConsultaP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridConsultaP_CellDoubleClick);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(388, 12);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(63, 23);
            this.btn_Buscar.TabIndex = 5;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // PalavraChave
            // 
            this.PalavraChave.Location = new System.Drawing.Point(97, 14);
            this.PalavraChave.Name = "PalavraChave";
            this.PalavraChave.Size = new System.Drawing.Size(285, 20);
            this.PalavraChave.TabIndex = 6;
            // 
            // lbl_palavrachave
            // 
            this.lbl_palavrachave.AutoSize = true;
            this.lbl_palavrachave.Location = new System.Drawing.Point(9, 17);
            this.lbl_palavrachave.Name = "lbl_palavrachave";
            this.lbl_palavrachave.Size = new System.Drawing.Size(80, 13);
            this.lbl_palavrachave.TabIndex = 7;
            this.lbl_palavrachave.Text = "Palavra Chave:";
            // 
            // btn_Retornar
            // 
            this.btn_Retornar.Location = new System.Drawing.Point(469, 12);
            this.btn_Retornar.Name = "btn_Retornar";
            this.btn_Retornar.Size = new System.Drawing.Size(63, 23);
            this.btn_Retornar.TabIndex = 8;
            this.btn_Retornar.Text = "Retornar";
            this.btn_Retornar.UseVisualStyleBackColor = true;
            this.btn_Retornar.Click += new System.EventHandler(this.btn_Retornar_Click);
            // 
            // AlternaModo
            // 
            this.AlternaModo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AlternaModo.Controls.Add(this.Load);
            this.AlternaModo.Controls.Add(this.panelInferior);
            this.AlternaModo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlternaModo.Location = new System.Drawing.Point(0, 0);
            this.AlternaModo.Name = "AlternaModo";
            this.AlternaModo.Size = new System.Drawing.Size(544, 450);
            this.AlternaModo.TabIndex = 3;
            // 
            // Load
            // 
            this.Load.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Load.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Load.ErrorImage = null;
            this.Load.Image = global::ProjectP3.Properties.Resources.load;
            this.Load.InitialImage = null;
            this.Load.Location = new System.Drawing.Point(245, 169);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(41, 41);
            this.Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Load.TabIndex = 5;
            this.Load.TabStop = false;
            this.Load.Visible = false;
            // 
            // FormPadrao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 450);
            this.Controls.Add(this.AlternaModo);
            this.Controls.Add(this.btn_Retornar);
            this.Controls.Add(this.lbl_palavrachave);
            this.Controls.Add(this.PalavraChave);
            this.Controls.Add(this.GridConsultaP);
            this.Controls.Add(this.btn_Buscar);
            this.Name = "FormPadrao";
            this.Text = "FormPadrao";
            this.panelInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridConsultaP)).EndInit();
            this.AlternaModo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Load)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Button btnSalvar;
        protected System.Windows.Forms.Button btnLimpar;
        protected System.Windows.Forms.Button btnConsultar;
        public System.Windows.Forms.DataGridView GridConsultaP;
        public System.Windows.Forms.Panel panelInferior;
        public System.Windows.Forms.Button btn_Buscar;
        public System.Windows.Forms.Button btn_Retornar;
        public System.Windows.Forms.Panel AlternaModo;
        public System.Windows.Forms.TextBox PalavraChave;
        public System.Windows.Forms.Label lbl_palavrachave;
        protected System.Windows.Forms.Button btn_Excluir;
        public System.Windows.Forms.PictureBox Load;
    }
}