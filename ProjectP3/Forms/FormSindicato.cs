using miscellaneous.Models;
using ProjectP3.Others;
using ProjectP3.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectP3.Forms
{
    public partial class FormSindicato : FormPadrao
    {
        public FormSindicato()
        {
            InitializeComponent();
            GridConsultaP.BuilderColumn("SindicatosId");
            GridConsultaP.BuilderColumn("Nome", "Sindicato", DataGridViewAutoSizeColumnMode.Fill);

            this.GridConsultaP.Size = new System.Drawing.Size(367, 140);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            SindicatosId.Clear();
            Nome.Clear();
            btn_Excluir.Visible = false;
        }

        public async override void GridConsultaP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btn_Excluir.Visible = true;
                var id = GridConsultaP.CurrentRow.Cells["SindicatosId"].Value.ToString();
                var Sindicato = await new Services<Sindicato>().GetById("api/Sindicatos/Id", id);

                SindicatosId.Text = Sindicato.SindicatosId.ToString();
                Nome.Text = Sindicato.Nome;

                AlternaModo.Visible = true;
                GridConsultaP.Rows.Clear();
            }
            catch (Exception M)
            {

                MessageBox.Show(M.Message);
            }

        }

        public override bool validacoes()
        {
            if (string.IsNullOrEmpty(Nome.Text))
            {
                MessageBox.Show("Preencher Sindicato.");
                return false;
            }
            return true;
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {

            if (validacoes())
            {                
                try
                {
                    Sindicato Sindicato = new Sindicato();
                    Sindicato.Nome = Nome.Text;

                    if (string.IsNullOrEmpty(SindicatosId.Text))
                    {
                        var result = await new Services<Sindicato>().Post("api/Sindicatos", Sindicato);
                        if (result.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Inserido com Sucesso.");

                        }
                    }
                    else
                    {
                        Sindicato.SindicatosId = Convert.ToInt32(SindicatosId.Text);
                        var result = await new Services<Sindicato>().Put("api/Sindicatos", Sindicato);
                        if (result.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Alterado com Sucesso.");

                        }
                    }

                }

                catch (Exception M)
                {

                    MessageBox.Show(M.Message);
                }

            }
            

        }

        private async void btn_Buscar_Click(object sender, EventArgs e)
        {
            var Sindicato = await new Services<Sindicato>().Get("api/Sindicatos");

            GridConsultaP.LoadFromList(Sindicato);
        }

        private async  void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este Sindicato?", "Exclusão Sindicato", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var result = await new Services<Sindicato>().Delete("api/Sindicatos", SindicatosId.Text);
                if (result.IsSuccessStatusCode)
                {
                    LimpaCadastro();
                    MessageBox.Show("Excluido com Sucesso.");
                }
            }
        }
    }
}
