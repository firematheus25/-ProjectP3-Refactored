using miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Humanizer;
using ProjectP3.Services;
using ProjectP3.Others;
using ProjectP3.MDI;
using ProjectP3.Forms.FormConsulta;

namespace ProjectP3
{
    public partial class FormRegistroPonto : FormPadrao
    {
        public FormRegistroPonto()
        {
            InitializeComponent();
            Entrada.Value = DateTimePicker.MinimumDateTime;
            Saida.Value = DateTimePicker.MinimumDateTime;
            this.GridConsultaP.Size = new System.Drawing.Size(400, 183);

            GridConsultaP.BuilderColumn("RegistroPontoId");
            GridConsultaP.BuilderColumn("funcionariosId", "Matrícula");
            GridConsultaP.BuilderColumn("Nome", "Nome", DataGridViewAutoSizeColumnMode.Fill);
            GridConsultaP.BuilderColumn("Horas", "Horas");
            GridConsultaP.BuilderColumn("DtPonto", "Data", DataGridViewAutoSizeColumnMode.None, "dd/MM/yyyy");

            FuncionariosId.TxtCodigo.Enabled = false;

        }


        public override void LimpaCadastro()
        {
            RegistroPontoId.Clear();
            FuncionariosId.Clear();
            DtPonto.Clear();
            Entrada.Value = DateTimePicker.MinimumDateTime;
            Saida.Value = DateTimePicker.MinimumDateTime;
            Horas.Clear();
            btn_Excluir.Visible = false;
        }

        public override bool validacoes()
        {
            string message = null;

            if (string.IsNullOrEmpty(FuncionariosId.TxtCodigo.Text))
            {
                message += "Preencher 'Funcionário'\n";
            }

            if (DtPonto.Date == null)
            {
                message += "Preencher 'Data'\n";
            }

            if (Entrada.Value == DateTimePicker.MinimumDateTime)
            {
                message += "Preencher 'Entrada'\n";
            }

            if (Saida.Value == DateTimePicker.MinimumDateTime)
            {
                message += "Preencher 'Saída'\n";
            }

            if (Saida.Value < Entrada.Value)
            {
                MessageBox.Show("Horário de entrada maior do que o horário de saída");
            }
            if (string.IsNullOrEmpty(Horas.Text))
            {
                Saida.Value = DateTimePicker.MinimumDateTime;
                Saida.Focus();
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCadastro();
        }

        public override async void GridConsultaP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btn_Excluir.Visible = true;
                FuncionariosId.Enabled = false;
                var id = GridConsultaP.CurrentRow.Cells["RegistroPontoId"].Value.ToString();
                var Ponto = await new Services<RegistroPonto>().GetById("api/RegistroPontos/Id", id);

                RegistroPontoId.Text = Convert.ToString(Ponto.RegistroPontoId);
                FuncionariosId.TxtCodigo.Text = Convert.ToString(Ponto.FuncionariosId);
                FuncionariosId.TxtDescricao.Text = Ponto.Nome;
                DtPonto.Date = Ponto.DtPonto;
                Entrada.Value = Convert.ToDateTime(Ponto.Entrada);
                Saida.Value = Convert.ToDateTime(Ponto.Saida);
                Horas.Text = Ponto.Horas;

                AlternaModo.Visible = true;
                GridConsultaP.Rows.Clear();
            }
            catch (Exception M)
            {

                MessageBox.Show(M.Message);
            }

        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacoes())
                {
                    var Ponto = new RegistroPonto();

                    Ponto.FuncionariosId = Convert.ToInt32(FuncionariosId.TxtCodigo.Text);
                    Ponto.Nome = FuncionariosId.TxtDescricao.Text;
                    Ponto.DtPonto = DtPonto.Date.Value;
                    Ponto.Entrada = Entrada.Value.TimeOfDay.ToString();
                    Ponto.Saida = Saida.Value.TimeOfDay.ToString();
                    Ponto.Horas = Horas.Text;

                    var Erro = await new Services<RegistroPonto>().GetByIds("api/RegistroPontos/Ids", Ponto.FuncionariosId.ToString());
                    if (string.IsNullOrEmpty(RegistroPontoId.Text))
                    {
                        foreach (var item in Erro)
                        {
                            if (item.DtPonto == Ponto.DtPonto)
                            {
                                MessageBox.Show("Ponto já cadastrado neste dia");
                                return;
                            }
                        }
                    }



                    if (string.IsNullOrEmpty(RegistroPontoId.Text))
                    {
                        var Result = await new Services<RegistroPonto>().Post("api/RegistroPontos", Ponto);
                        if (Result.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Inserido com sucesso");
                            LimpaCadastro();
                        }
                        if (Result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            MessageBox.Show("Já existe ponto registrado neste dia");
                        }

                    }
                    else
                    {
                        Ponto.RegistroPontoId = Convert.ToInt32(RegistroPontoId.Text);
                        var Result = await new Services<RegistroPonto>().Put("api/RegistroPontos", Ponto);
                        if (Result.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Alterado com sucesso");
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

        private void Saida_ValueChanged(object sender, EventArgs e)
        {
            if (Saida.Value == DateTimePicker.MinimumDateTime || Saida.Value.TimeOfDay < Entrada.Value.TimeOfDay)
            {

            }
            if (Saida.Value.TimeOfDay > Entrada.Value.TimeOfDay)
            {
                Horas.Text = Convert.ToString(Saida.Value.TimeOfDay - Entrada.Value.TimeOfDay);
            }
        }

        private void FuncionariosId_ConsultarClick(object sender, EventArgs e)
        {
            var frmConsulta = new FuncionariosConsulta();
            frmConsulta.Owner = this;
            frmConsulta.ShowDialog();
        }

        private void FuncionariosId_ConsultarAPI(object sender)
        {

        }

        private async void btn_Buscar_Click(object sender, EventArgs e)
        {
            var pontos = await new Services<RegistroPonto>().Get("api/RegistroPontos");
            
            GridConsultaP.LoadFromList(pontos);
        }

        private async void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este registro de ponto?", "Exclusão Registro Ponto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var result = await new Services<RegistroPonto>().Delete("api/registropontos", RegistroPontoId.Text);
                if (result.IsSuccessStatusCode)
                {
                    LimpaCadastro();
                    MessageBox.Show("Excluido com Sucesso.");                    
                }
            }
        }
    }
}
