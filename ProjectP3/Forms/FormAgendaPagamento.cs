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
    public partial class FormAgendaPagamento : FormPadrao
    {
        public FormAgendaPagamento()
        {
            InitializeComponent();


            GridConsultaP.BuilderColumn("AgendaId");
            GridConsultaP.BuilderColumn("Agenda", "Agenda", DataGridViewAutoSizeColumnMode.Fill);


            
            Tipo.Items.Add("Mensal");
            Tipo.Items.Add("Semanal");
            Tipo.Items.Add("Bi-semanal");


            for (int i = 1; i <= 31; i++)
            {
                if (i == 31)
                {
                    Dia.Items.Add("$");
                }
                else
                {
                    Dia.Items.Add(i);
                }
                
            }       

            DiaSemana.Items.AddRange(new object[] { "Domingo", "Segunda-Feira", "Terça-Feira", "Quarta-Feira", "Quinta-Feira", "Sexta-Feira", "Sábado" });

            this.GridConsultaP.Size = new System.Drawing.Size(372 , 185);

            Dia.Enabled = false;
            DiaSemana.Enabled = false;
            
        }


        public override void LimpaCadastro()
        {
            AgendaId.Clear();
            Tipo.SelectedIndex = -1;
            Dia.SelectedIndex = -1;
            DiaSemana.SelectedIndex = -1;
            agenda.Clear();
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Tipo.SelectedIndex = -1;
            Dia.SelectedIndex = -1;
            DiaSemana.SelectedIndex = -1;
            Dia.Enabled = false;
            DiaSemana.Enabled = false;
            agenda.Clear();
            btn_Excluir.Visible = false;
        }

        public async override void GridConsultaP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Excluir.Visible = true;
            var Id = GridConsultaP.CurrentRow.Cells["AgendaId"].Value.ToString();
            var result = await new Services<AgendaPagamento>().GetById("api/AgendaPagamento/Id", Id);
            int i = 0;

            AgendaId.Text = Convert.ToString(result.AgendaId);
            foreach (var item in Tipo.Items)
            {                
                if (item.ToString() == result.Tipo)
                {
                    Tipo.SelectedIndex = i;
                    break;
                }
                i++;
            }

            if (result.Dia != null)
            {
                i = 0;
                foreach (var item in Dia.Items)
                {
                    if (item.ToString() == result.Dia)
                    {
                        Dia.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
            else
            {
                i = 0;
                foreach (var item in DiaSemana.Items)
                {
                    if (item.ToString() == result.DiaSemana)
                    {
                        DiaSemana.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            agenda.Text = result.Agenda;

            AlternaModo.Visible = true;


        }

        public override bool validacoes()
        {
            string message = null;

            if (Tipo.SelectedIndex == 0  && Dia.SelectedIndex == -1)
            {
                message += "Preencher 'Dia'\n";
            }

            if (Tipo.SelectedIndex != 0 && DiaSemana.SelectedIndex == -1)
            {
                message += "Preencher 'Dia'\n";
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
                    AgendaPagamento Agenda = new AgendaPagamento();


                    Agenda.Tipo = Tipo.SelectedItem.ToString();

                    if (Dia.SelectedIndex != -1)
                    {
                        Agenda.Dia = Dia.SelectedItem.ToString();
                    }
                    else
                    {
                        Agenda.DiaSemana = DiaSemana.SelectedItem.ToString();
                    }

                    Agenda.Agenda = agenda.Text;

                    if (string.IsNullOrEmpty(AgendaId.Text))
                    {
                        var Result = await new Services<AgendaPagamento>().Post("api/AgendaPagamento", Agenda);
                        if (Result.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Inserido com Sucesso");
                            LimpaCadastro();
                        }
                    }
                    else
                    {
                        Agenda.AgendaId = Convert.ToInt32(AgendaId.Text);
                        var Result = await new Services<AgendaPagamento>().Put("api/AgendaPagamento", Agenda);
                        if (Result.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Alterado com Sucesso");
                            LimpaCadastro();
                        }
                    }

                }

            }
            catch (Exception M)
            {

                MessageBox.Show(M.Message);
            }

        }


        private void Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            agenda.Clear();
            if (Tipo.SelectedIndex == 0)
            {
                AlteraComboBox();
            }
            else
            {
                AlteraComboBox();
            }
                
        }

        private void AlteraComboBox()
        {
            if (Tipo.SelectedIndex == 0)
            {
                DiaSemana.Enabled = false;
                DiaSemana.Visible = false;
                DiaSemana.SelectedIndex = -1;
                Dia.Enabled = true;
                Dia.Visible = true;
                Dia.SelectedIndex = -1;


            }
            else
            {
                DiaSemana.Enabled = true;
                DiaSemana.Visible = true;
                DiaSemana.SelectedIndex = -1;
                Dia.Enabled = false;
                Dia.Visible = false;
                Dia.SelectedIndex = -1;
            }


        }

        private void DiaSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DiaSemana.SelectedIndex != -1)
                {
                    agenda.Text = Tipo.SelectedItem.ToString() + " - " + DiaSemana.SelectedItem.ToString();
                }               
            }
            catch (Exception M)
            {
                MessageBox.Show(M.Message);
            }
            

        }

        private void Dia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Dia.SelectedIndex != -1)
                {
                    agenda.Text = Tipo.SelectedItem.ToString() + " " + Dia.SelectedItem.ToString();
                }
                
            }
            catch (Exception M)
            {
                MessageBox.Show(M.Message);
            }

        }

        private async void btn_Buscar_Click(object sender, EventArgs e)
        {
            var result = await new Services<AgendaPagamento>().Get("api/AgendaPagamento");

            GridConsultaP.LoadFromList(result);
        }

        private async void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir esta agenda de pagamento?", "Exclusão Agenda pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var result = await new Services<AgendaPagamento>().Delete("api/agendapagamento", AgendaId.Text);
                if (result.IsSuccessStatusCode)
                {
                    LimpaCadastro();
                    MessageBox.Show("Excluido com Sucesso.");
                }
            }
        }
    }
}
