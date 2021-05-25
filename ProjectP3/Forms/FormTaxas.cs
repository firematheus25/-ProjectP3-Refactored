using miscellaneous.Models;
using ProjectP3.Forms.FormConsulta;
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
    public partial class FormTaxas : FormPadrao
    {
        public FormTaxas()
        {
            InitializeComponent();

            GridConsultaP.BuilderColumn("taxaservicoId");
            GridConsultaP.BuilderColumn("FuncionarioSindicalId", "Matricula Sindicato");
            GridConsultaP.BuilderColumn("Nome", "Funcionário", DataGridViewAutoSizeColumnMode.Fill);
            GridConsultaP.BuilderColumn("taxaservico", "Taxa");
            GridConsultaP.BuilderColumn("competencia", "Competência", DataGridViewAutoSizeColumnMode.None, "MM/yyyy");


            this.GridConsultaP.Size = new System.Drawing.Size(397, 184);

           
        }

        public async override void GridConsultaP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btn_Excluir.Visible = true;
                var id = GridConsultaP.CurrentRow.Cells["TaxaServicoId"].Value.ToString();
                var taxa = await new Services<TaxasServico>().GetById("api/Taxasservico/Id", id);

                TaxaServicoId.Text = Convert.ToString(taxa.TaxaServicoId);
                FuncionariosId.Enabled = false;
                FuncionariosId.TxtCodigo.Text = Convert.ToString(taxa.FuncionarioSindicalId);
                FuncionariosId.TxtDescricao.Text = taxa.Nome;
                TaxaServico.Text = Convert.ToString(taxa.TaxaServico);
                Competencia.Date = taxa.Competencia;

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
            string message = null;

            if (string.IsNullOrEmpty(FuncionariosId.TxtCodigo.Text))
            {
                message += "Preencher 'Funcionário'\n";
            }

            if (Competencia.Date == null)
            {
                message += "Preencher 'Competência'\n";
            }

            if (string.IsNullOrEmpty(TaxaServico.Text))
            {
                message += "Preencher 'Taxa de serviço'\n";
            }

            if (message == null)
            {
                return true;
            }
            else
            {
                MessageBox.Show(message);
                return false;
            }

        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (validacoes())
                {
                    
                    TaxasServico taxas = new TaxasServico();

                    taxas.FuncionarioSindicalId = Convert.ToInt32(FuncionariosId.TxtCodigo.Text);
                    taxas.Nome = FuncionariosId.TxtDescricao.Text;
                    taxas.Competencia = Competencia.Date.Value;
                    taxas.TaxaServico = Convert.ToDouble(TaxaServico.Text);


                    if (string.IsNullOrEmpty(TaxaServicoId.Text))
                    {
                        var result = await new Services<TaxasServico>().Post("api/TaxasServico", taxas);
                        if (result.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Inserido com sucesso.");
                        }

                    }
                    else
                    {
                        taxas.TaxaServicoId = Convert.ToInt32(TaxaServicoId.Text);
                        var result = await new Services<TaxasServico>().Put("api/TaxasServico", taxas);
                        if (result.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Alterado com sucesso.");
                        }
                    }
                }
                


            }
            catch (Exception M)
            {

                MessageBox.Show(M.Message);
            }
        }

        private void FuncionariosId_ConsultarAPI(object sender) { }

        private void FuncionariosId_ConsultarClick(object sender, EventArgs e)
        {
            var frmConsulta = new FuncionarioSindicalConsulta();
            frmConsulta.Owner = this;
            frmConsulta.ShowDialog();
        }

        private async void btn_Buscar_Click(object sender, EventArgs e)
        {
            var taxas = await new Services<TaxasServico>().Get("api/TaxasServico");

            GridConsultaP.LoadFromList(taxas);
        }

        private async void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir esta Taxa?", "Exclusão Taxa Sindical", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var result = await new Services<TaxasServico>().Delete("api/TaxasServico", TaxaServicoId.Text);
                if (result.IsSuccessStatusCode)
                {
                    LimpaCadastro();
                    MessageBox.Show("Excluido com Sucesso.");
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCadastro();
        }

        public override void LimpaCadastro()
        {
            TaxaServicoId.Clear();
            FuncionariosId.Clear();
            TaxaServico.Clear();
            Competencia.Clear();
            btn_Excluir.Visible = false;
        }
    }
}
