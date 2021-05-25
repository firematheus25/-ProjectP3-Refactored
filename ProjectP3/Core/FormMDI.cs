using ProjectP3.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectP3.MDI
{
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFuncionario F = new FormFuncionario();
            F.MdiParent = this;
            F.Show();
        }

        private void registroDePontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegistroPonto F = new FormRegistroPonto();
            F.MdiParent = this;
            F.Show();
        }

        private void cadastroDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVendas F = new FormVendas();
            F.MdiParent = this;
            F.Show();
        }

        private void folhaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFolha F = new FormFolha();
            F.MdiParent = this;
            F.Show();
        }

        private void taxasServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTaxas f = new FormTaxas();
            f.MdiParent = this;
            f.Show();
        }

        private void agendaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAgendaPagamento f = new FormAgendaPagamento();
            f.MdiParent = this;
            f.Show();
        }

        private void sindicatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSindicato f = new FormSindicato();
            f.MdiParent = this;
            f.Show();
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
