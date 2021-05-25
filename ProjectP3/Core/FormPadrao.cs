using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectP3
{
    public partial class FormPadrao : Form
    {
        public FormPadrao()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           //Implementar Heranca
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Implementar na heranca
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Implementar na heranca
            PalavraChave.Focus();
            AlternaModo.Visible = false;
            
        }

        private void btn_Retornar_Click(object sender, EventArgs e)
        {
            AlternaModo.Visible = true;
        }

        public virtual void GridConsultaP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Implementar na Heranca
            btnSalvar.Text = "Alterar";
            AlternaModo.Visible = true;
            
        }

        public virtual void LimpaCadastro()
        {
            //Implementat na Heranca
        }

        public virtual bool validacoes()
        {
            //Implementat na Heranca
            return true;
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            //Implementar na Heranca
        }
        public void freeze()
        {
            AlternaModo.Enabled = false;
            Load.Visible = true;
        }

        public void unfreeze()
        {
            AlternaModo.Enabled = true;
            Load.Visible = false;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            freeze();
            unfreeze();
        }
    }
}
