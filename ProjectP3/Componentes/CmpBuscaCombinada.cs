using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectP3.componentes
{
    [System.ComponentModel.DesignerCategory("Code")]

    public class CmpBuscaCombinada : UserControl
    {

        public CmpBuscaCombinada()
        {
            InitializeComponent();
        }

        // Componentes da Classe
        public System.Windows.Forms.MaskedTextBox TxtCodigo;
        public System.Windows.Forms.TextBox TxtDescricao;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Timer temporizador;

        //Delegate do Evento próprio do componente
        public delegate void EventHandlerCustom(object sender);

        //Evento ConsultaAPI
        public event EventHandlerCustom ConsultarAPI;
        public event EventHandlerCustom CadastroRef;

        //Evento Click do botão Consultar
        public event EventHandler ConsultarClick;

        // Variável de designer necessária.
        private System.ComponentModel.IContainer components = null;

        //Identificador para alteração do txtCodigo de forma que não dispare o evento ........
        private bool ByCode;

        //Texto no evento de consulta
        private bool CodAlterado { get; set; }
        public Object DataSource { get; private set; }




        public int LarguraCodigo
        {
            get { return TxtCodigo.Size.Width; }
            set
            {
                TxtCodigo.Width = value;
                BtnOk.Location = new Point(value - 20, 2);
                TxtDescricao.Location = new Point(BtnOk.Location.X + 30, 1);
                TxtDescricao.Width = this.Width - TxtCodigo.Width - 10;
            }
        }

        public Color CorFundo
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        public string Mascara
        {
            get { return TxtCodigo.Mask; }
            set { TxtCodigo.Mask = value; }
        }

        public bool ExisteDescricao
        {
            get { return !string.IsNullOrEmpty(TxtDescricao.Text.Trim()); }
        }

        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void BtnOk_Click(object Sender, EventArgs e)
        {
            //Quando Clica no BtnOk Dispara o evento ConsultarClick
            if (ConsultarClick != null)
            {
                ConsultarClick(Sender, e);
            }
        }






        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            /*
             * A cada mudança no campo de texto, reinicia o temporizador desde que:
             *  ByCode = false : Se alteração vier da digitação na caixa de texto ou buscacombinada.TxtCodigo.text = "algo"
             *  ByCode = true  : Se alteração vier através das funções SetValues
             */

            if (ByCode)
            {
                CodAlterado = false;
            }
            else
            {
                CodAlterado = true;
                TxtDescricao.Clear();
                DataSource = null;

                temporizador.Stop();
                temporizador.Start();
            }
        }

        //Executado ao sair do campo de texto
        private void TxtCodigo_Leave(object Sender, System.EventArgs e)
        {
            temporizador.Stop();
            if (CodAlterado)
            {
                CodAlterado = false;
                ConsultarAPI(this);
            }
        }

        //Executado após 1 segundo sem alteração no campo de texto
        private void Temporizador_Cronometro(object Sender, EventArgs e)
        {
            temporizador.Stop();
            CodAlterado = false;
            ConsultarAPI(this);
        }

        private void TxtCodigo_KeyDown(object Sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                BtnOk.PerformClick();
            }
            else if (e.KeyCode == Keys.F2 && CadastroRef != null)
            {
                CadastroRef(this);
                /*
                 * Add ao evento F3Down o chamada ao respectivo formulário.
                 * Exemplo (o menu precisa estar public):
                 * 
                 * if ((MdiParent as frmMdi).mnCnae.Tag.ToString() == "E")
                 *  (MdiParent as frmMdi).mnCnae.PerformClick();
                 *  
                 */
            }
        }

        //Metodo para setar os valores do componente internamente
        public void SetValues<T>(string codigo, string descricao, T dataSource)
        {
            ByCode = true;

            TxtCodigo.Text = codigo;
            TxtDescricao.Text = descricao;
            DataSource = dataSource;

            ByCode = false;
        }

        public void SetValues<T>(int codigo, string descricao, T dataSource)
        {
            ByCode = true;

            TxtCodigo.Text = Convert.ToString(codigo);
            TxtDescricao.Text = descricao;
            DataSource = dataSource;

            ByCode = false;
        }


        public T GetValues<T>()
        {
            return (T)DataSource;
        }


        //Metodo para limpar o componente
        public void Clear()
        {
            TxtCodigo.Clear();
            TxtDescricao.Clear();
            DataSource = null;
        }



        private void InitializeComponent()
        {
            this.TxtCodigo = new System.Windows.Forms.MaskedTextBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.TxtDescricao = new System.Windows.Forms.TextBox();
            this.temporizador = new System.Windows.Forms.Timer();

            this.SuspendLayout();

            // 
            // codigoTxt
            // 
            this.TxtCodigo.Name = "codigoText";
            this.TxtCodigo.Location = new System.Drawing.Point(0, 1);
            this.TxtCodigo.Size = new Size(100, 20);
            this.TxtCodigo.TabIndex = 0;
            this.TxtCodigo.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            this.TxtCodigo.TextChanged += new EventHandler(TxtCodigo_TextChanged);
            this.TxtCodigo.Leave += new EventHandler(TxtCodigo_Leave);
            this.TxtCodigo.KeyDown += new KeyEventHandler(TxtCodigo_KeyDown);
            // 
            // okBtn
            // 
            this.BtnOk.Location = new System.Drawing.Point(80, 2);
            this.BtnOk.Name = "buscaButton";
            this.BtnOk.Size = new System.Drawing.Size(19, 18);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Image = global::ProjectP3.Properties.Resources.magnifier;
            this.BtnOk.TabStop = false;
            this.BtnOk.Click += new EventHandler(BtnOk_Click);
            // 
            // descText
            // 
            this.TxtDescricao.Name = "descText";
            this.TxtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDescricao.Location = new System.Drawing.Point(110, 1);
            this.TxtDescricao.Size = new System.Drawing.Size(300, 20);
            this.TxtDescricao.TabIndex = 2;
            this.TxtDescricao.ReadOnly = true;
            this.TxtDescricao.TabStop = false;
            // 
            // timer1
            // 
            this.temporizador.Interval = 1000;
            this.temporizador.Enabled = true;
            this.temporizador.Stop();
            this.temporizador.Tick += new EventHandler(Temporizador_Cronometro);
            //  
            // CmpBuscaCombinada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.TxtDescricao);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TxtCodigo);
            this.Name = "CmpBuscaCombinada";
            this.Size = new System.Drawing.Size(410, 21);
            this.ActiveControl = this.TxtCodigo;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
