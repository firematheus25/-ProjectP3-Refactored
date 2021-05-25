using miscellaneous.Models;
using Newtonsoft.Json;
using ProjectP3.Forms.FormConsulta;
using ProjectP3.MDI;
using ProjectP3.Others;
using ProjectP3.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectP3
{
    public partial class FormFuncionario : FormPadrao
    {
        public FormFuncionario()
        {
            InitializeComponent();


            GridConsultaP.BuilderColumn("funcionariosId", "Matrícula");
            GridConsultaP.BuilderColumn("Nome", "Nome", DataGridViewAutoSizeColumnMode.Fill);
            GridConsultaP.BuilderColumn("Tipo", "Tipo", DataGridViewAutoSizeColumnMode.Fill);
            GridConsultaP.BuilderColumn("Agenda", "Pagamento", DataGridViewAutoSizeColumnMode.Fill);

            MetodoPagamento.Items.Add("1 - Cheque pelos correios");
            MetodoPagamento.Items.Add("2 - Cheque em mãos");
            MetodoPagamento.Items.Add("3 - Deposito em conta bancária");
            
            
            this.GridConsultaP.Size = new System.Drawing.Size(520, 448); 


            Salario.Visible = false;
            lbl_Salario.Visible = false;
            TaxaComissao.Visible = false;
            lbl_TaxaComissao.Visible = false;
            ValorHora.Visible = false;
            lbl_ValorHora.Visible = false;
            FuncionarioSindicalId.TxtCodigo.Visible = false;
            AgendaId.TxtCodigo.Visible = false;

            MetodoPagamento.DropDownWidth();            
        }


        public override bool validacoes()
        {
            string message = null;

            if (!Assalariado.Checked && !Comissionado.Checked && !Horista.Checked)
            {
                message += "Preencher 'Tipo Funcionário'\n";
            }

            if (string.IsNullOrEmpty(Nome.Text))
            {
                message += "Preencher 'Nome'\n";
            }

            if (string.IsNullOrEmpty(AgendaId.TxtDescricao.Text))
            {
                message += "Preencher 'Agenda Pagamento'\n";
            }

            if (MetodoPagamento.SelectedIndex == -1)
            {
                message += "Preencher 'Método de Pagamento'\n";
            }

            if (Assalariado.Checked)
            {
                if (string.IsNullOrEmpty(Salario.Text))
                {
                    message += "Preencher 'Salário'\n"; 
                }
            }
            if (Comissionado.Checked)
            {
                if (string.IsNullOrEmpty(Salario.Text))
                {
                    message += "Preencher 'Salário'\n";
                }
                if (string.IsNullOrEmpty(TaxaComissao.Text))
                {
                    message += "Preencher 'Taxa Comissão'\n";
                }
            }

            if (Horista.Checked)
            {
                if (string.IsNullOrEmpty(ValorHora.Text))
                {
                    message += "Preencher 'Valor Hora'\n";
                }
            }

            if (!string.IsNullOrEmpty(FuncionarioSindicalId.TxtCodigo.Text))
            {
                if (string.IsNullOrEmpty(TaxaSindical.Text))
                {
                    message += "Preencher 'Taxa Sindical'\n";

                }
            }

            if (Agencia.Text.Length > 4)
            {
                message += "Agência deve conter no máximo 4 algarismos\n";
            }

            if (Conta.Text.Length > 8)
            {
                message += "Conta deve conter no máximo 8 algarismos\n";
            }

            if (Operacao.Text.Length > 3)
            {
                message += "Operação deve conter no máximo 3 algarismos\n";
            }

            if (!string.IsNullOrEmpty(Cep.Text))
            {
                if (Cep.Text.Length != 8)
                {
                    message += "CEP deve conter 8 algarismos\n";
                }
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

        public override void LimpaCadastro()
        {
            Assalariado.Checked = false;
            Horista.Checked = false;
            Comissionado.Checked = false;
            Salario.Visible = false;
            lbl_Salario.Visible = false;
            TaxaComissao.Visible = false;
            lbl_TaxaComissao.Visible = false;
            ValorHora.Visible = false;
            lbl_ValorHora.Visible = false;
            lbl_TxSindical.Visible = false;
            TaxaSindical.Visible = false;
            salario_obrigado.Visible = false;
            taxacomissao_Obrigado.Visible = false;
            sindical_obrigado.Visible = false;
            btn_Excluir.Visible = false;
            btnSalvar.Text = "Salvar";

            FuncionariosId.Clear();
            Nome.Clear();
            MetodoPagamento.SelectedIndex = -1;
            Salario.Clear();
            Cep.Clear();
            Rua.Clear();
            Numero.Clear();
            Cidade.Clear();
            Bairro.Clear();
            Complemento.Clear();
            UF.SelectedIndex = -1;
            Banco.Clear();
            Agencia.Clear();
            Conta.Clear();
            Operacao.Clear();
            Salario.Clear();
            TaxaComissao.Clear();
            ValorHora.Clear();
            FuncionarioSindicalId.Clear();
            AgendaId.Clear();
            TaxaSindical.Clear();

        }

        //Preenche Cadastro
        public override async void GridConsultaP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            freeze();
            try
            {
                LimpaCadastro();

                btn_Excluir.Visible = true;
                btnSalvar.Text = "Alterar";
                var id = GridConsultaP.CurrentRow.Cells["FuncionariosId"].Value.ToString();
                var funcionario = await new Services<FuncionarioVw>().GetById("api/funcionarios/Id", id);

                FuncionariosId.Text = funcionario.FuncionariosId.ToString();
                if (funcionario.TipoFuncionario == 1)
                {
                    Salario.Focus();
                    Assalariado.Checked = true;
                    AssalariadoId.Text = Convert.ToString(funcionario.AssalariadoId);
                    Salario.Text = Convert.ToString(funcionario.Salario);
                }
                if (funcionario.TipoFuncionario == 2)
                {
                    Salario.Focus();
                    Comissionado.Checked = true;
                    ComissionadoId.Text = Convert.ToString(funcionario.ComissionadoId);
                    Salario.Text = Convert.ToString(funcionario.SalarioComissao);
                    TaxaComissao.Text = Convert.ToString(funcionario.TaxaComissao);
                }
                if (funcionario.TipoFuncionario == 3)
                {

                    Horista.Checked = true;
                    HoristaId.Text = Convert.ToString(funcionario.HoristaId);
                    ValorHora.Text = Convert.ToString(funcionario.ValorHora);
                    ValorHora.Focus();
                }


                if (!string.IsNullOrEmpty(funcionario.SindicatosId.ToString()))
                {
                    var result = await new Services<Sindicato>().GetById("api/Sindicatos/Id", funcionario.SindicatosId.ToString());
                    FuncionarioSindicalId.TxtCodigo.Text = funcionario.SindicatosId.ToString();
                    FuncionarioSindicalId.TxtDescricao.Text = result.Nome;
                    TaxaSindical.Text = Convert.ToString(funcionario.TaxaSindical);
                    lbl_TxSindical.Visible = true;
                    TaxaSindical.Visible = true;
                    sindical_obrigado.Visible = true;
                }


                Nome.Text = funcionario.Nome;
                AgendaId.TxtCodigo.Text = Convert.ToString(funcionario.AgendaId);
                AgendaId.TxtDescricao.Text = funcionario.Agenda;

                MetodoPagamento.SelectedIndex = ((int)(funcionario.MetodoPagamento - 1));

                //Endereco
                Cep.Text = funcionario.CEP;
                Rua.Text = funcionario.Rua;
                Cidade.Text = funcionario.Cidade;
                Complemento.Text = funcionario.Complemento;
                Bairro.Text = funcionario.Bairro;
                Numero.Text = funcionario.Numero;
                UF.SelectIndex(funcionario.UF);

                //Dados Bancário
                Banco.Text = funcionario.Banco;
                Agencia.Text = funcionario.Agencia;
                Conta.Text = funcionario.Conta;
                Operacao.Text = funcionario.Operacao;

                AlternaModo.Visible = true;
                GridConsultaP.Rows.Clear();
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
            finally
            {
                unfreeze();
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {            
            try
            {
                freeze();
                if (validacoes())
                {
                    var Funcionario = new Funcionario();

                    if (!string.IsNullOrEmpty(FuncionariosId.Text))
                    {
                        Funcionario.FuncionariosId = Convert.ToInt32(FuncionariosId.Text);
                    }

                    Funcionario.Nome = Nome.Text;
                    Funcionario.MetodoPagamento = Convert.ToInt32(MetodoPagamento.Text.Substring(0, 1));
                    Funcionario.CEP = Cep.Text;
                    Funcionario.Rua = Rua.Text;
                    Funcionario.Numero = Numero.Text;
                    Funcionario.Cidade = Cidade.Text;
                    Funcionario.Bairro = Bairro.Text;
                    Funcionario.Complemento = Complemento.Text;
                    if (UF.SelectedIndex != -1)
                    {
                        Funcionario.UF = UF.Text.Substring(0, 2);
                    }                   
                    Funcionario.Banco = Banco.Text;
                    Funcionario.Agencia = Agencia.Text;
                    Funcionario.Conta = Conta.Text;
                    Funcionario.Operacao = Operacao.Text;

                    if (Assalariado.Checked) { Funcionario.TipoFuncionario = 1; }
                    if (Comissionado.Checked) { Funcionario.TipoFuncionario = 2; }
                    if (Horista.Checked) { Funcionario.TipoFuncionario = 3; }

                    if (!string.IsNullOrEmpty(AgendaId.TxtCodigo.Text))
                    {
                        Funcionario.AgendaId = Convert.ToInt32(AgendaId.TxtCodigo.Text);
                    }


                    int funcionariostransaction = 0;
                    if (string.IsNullOrEmpty(FuncionariosId.Text))
                    {
                        var Result = await new Services<Funcionario>().Post("api/Funcionarios/", Funcionario);
                        string Id = "0";
                        var Tentativa = await new Services<Funcionario>().GetById("api/funcionarios/FuncionariosId", Id);
                        funcionariostransaction = Tentativa.FuncionariosId;
                    }
                    else
                    {
                        var Result = await new Services<Funcionario>().Put("api/Funcionarios/", Funcionario);
                    }


                    // Verificacoes Sindicato
                    var U = await new Services<FuncionarioSindical>().GetById("api/FuncionariosSindicais/Funcionario", FuncionariosId.Text);
                    if (!string.IsNullOrEmpty(FuncionarioSindicalId.TxtCodigo.Text))
                    {
                        FuncionarioSindical FuncionarioSindical = new FuncionarioSindical();

                        if (string.IsNullOrEmpty(FuncionariosId.Text))
                        {
                            FuncionarioSindical.FuncionariosId = Convert.ToInt32(funcionariostransaction);
                        }
                        else
                        {
                            FuncionarioSindical.FuncionariosId = Convert.ToInt32(FuncionariosId.Text);
                        }
                        
                        FuncionarioSindical.Nome = Nome.Text;
                        FuncionarioSindical.SindicatosId = Convert.ToInt32(FuncionarioSindicalId.TxtCodigo.Text);
                        FuncionarioSindical.TaxaSindical = Convert.ToDouble(TaxaSindical.Text);

 
                        if (U == null)
                        {
                            await new Services<FuncionarioSindical>().Post("api/FuncionariosSindicais", FuncionarioSindical);
                        }
                        else
                        {
                            if (U.TaxaSindical != Convert.ToDouble(TaxaSindical.Text) || U.Nome != Nome.Text || U.SindicatosId != Convert.ToInt32(FuncionarioSindicalId.TxtCodigo.Text))
                            {
                                FuncionarioSindical.FuncionarioSindicalId = U.FuncionarioSindicalId;
                                await new Services<FuncionarioSindical>().Put("api/FuncionariosSindicais", FuncionarioSindical);
                            }
                        }
                    }
                    else
                    {
                        if (U != null)
                        {
                            await new Services<FuncionarioSindical>().Delete("api/FuncionariosSindicais", FuncionariosId.Text);
                        }                     
;                   }


                    if (Assalariado.Checked)
                    {
                        var Assalariado = new Assalariado();
                        if (string.IsNullOrEmpty(FuncionariosId.Text))
                        {
                            Assalariado.FuncionariosId = funcionariostransaction;
                        }
                        else
                        {
                            Assalariado.FuncionariosId = Convert.ToInt32(FuncionariosId.Text);
                        }
                        
                        Assalariado.Salario = Convert.ToDouble(Salario.Text);
                       

                        if (string.IsNullOrEmpty(AssalariadoId.Text))
                        {
                            var assa = await new Services<Assalariado>().Post("api/Assalariado", Assalariado);
                            if (assa.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Inserido com sucesso.");
                                LimpaCadastro();
                            }
                        }
                        else
                        {
                            Assalariado.AssalariadoId = Convert.ToInt32(AssalariadoId.Text);
                            var UpdAssa = await new Services<Assalariado>().Put("api/Assalariado", Assalariado);
                            if (UpdAssa.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Alterado com sucesso.");
                                LimpaCadastro();
                            }
                        }

                    }

                    if (Comissionado.Checked)
                    {
                        var Comissionado = new Comissionado();

                        if (string.IsNullOrEmpty(FuncionariosId.Text))
                        {
                            Comissionado.FuncionariosId = funcionariostransaction;
                        }
                        else
                        {
                            Comissionado.FuncionariosId = Convert.ToInt32(FuncionariosId.Text);
                        }

                        
                        Comissionado.Salario = Convert.ToDecimal(Salario.Text);
                        Comissionado.TaxaComissao = Convert.ToDecimal(TaxaComissao.Text);                        

                        if (string.IsNullOrEmpty(ComissionadoId.Text))
                        {
                            var com = await new Services<Comissionado>().Post("api/Comissionado", Comissionado);
                            
                            if (com.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Inserido com sucesso.");
                                LimpaCadastro();
                            }
                        }
                        else
                        {
                            Comissionado.ComissionadoId = Convert.ToInt32(ComissionadoId.Text);
                            var com = await new Services<Comissionado>().Put("api/Comissionado", Comissionado);
                            if (com.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Alterado com sucesso.");
                                LimpaCadastro();
                            }
                        }
                    }

                    if (Horista.Checked)
                    {

                        var Horista = new Horista();

                        if (string.IsNullOrEmpty(FuncionariosId.Text))
                        {
                            Horista.FuncionariosId = funcionariostransaction;
                        }
                        else
                        {
                            Horista.FuncionariosId = Convert.ToInt32(FuncionariosId.Text);
                        }

                        Horista.ValorHora = Convert.ToDouble(ValorHora.Text);

                       

                        if (string.IsNullOrEmpty(HoristaId.Text))
                        {
                            
                            var hor = await new Services<Horista>().Post("api/Horista", Horista);
                            if (hor.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Inserido com sucesso");
                                LimpaCadastro();
                            }
                        }
                        else
                        {
                            Horista.HoristaId = Convert.ToInt32(HoristaId.Text);
                            var hor = await new Services<Horista>().Put("api/Horista", Horista);
                            if (hor.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Alterado com sucesso.");
                                LimpaCadastro();
                            }
                        }

                    }
                }                                         
            }
            catch (Exception M)
            {
                MessageBox.Show(M.Message);
            }
            finally
            {
                unfreeze();
            }
        }

            
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCadastro();            
        }

        public async void Assalariado_CheckedChanged(object sender, EventArgs e)
        {
            freeze();
            try
            {
                if (Assalariado.Checked)
                {                    
                    if (string.IsNullOrEmpty(FuncionariosId.Text))
                    {
                        var result = await new Services<AgendaPagamento>().Get("api/AgendaPagamento");

                        foreach (var item in result)
                        {
                            if (item.Agenda == "Mensal $")
                            {
                                AgendaId.TxtCodigo.Text = item.AgendaId.ToString();
                                AgendaId.TxtDescricao.Text = item.Agenda;
                            }
                        }
                    }
                    Comissionado.Checked = false;
                    Horista.Checked = false;

                    ValorHora.Visible = false;
                    lbl_ValorHora.Visible = false;
                    TaxaComissao.Visible = false;
                    lbl_TaxaComissao.Visible = false;
                    taxacomissao_Obrigado.Visible = false;

                    salario_obrigado.Visible = true;

                    Salario.Visible = true;
                    lbl_Salario.Visible = true;

                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
            finally
            {
                unfreeze();
            }

        }

        private async void Comissionado_CheckedChanged(object sender, EventArgs e)
        {
            freeze();
            try
            {
                if (Comissionado.Checked)
                {

                    if (string.IsNullOrEmpty(FuncionariosId.Text))
                    {
                        
                        var result = await new Services<AgendaPagamento>().Get("api/AgendaPagamento");

                        foreach (var item in result)
                        {
                            if (item.Agenda == "Bi-semanal - Sexta-Feira")
                            {
                                AgendaId.TxtCodigo.Text = item.AgendaId.ToString();
                                AgendaId.TxtDescricao.Text = item.Agenda;
                            }
                        }
                        AlternaModo.Enabled = true;
                    }


                    Assalariado.Checked = false;
                    Horista.Checked = false;

                    ValorHora.Visible = false;
                    lbl_ValorHora.Visible = false;

                    lbl_Salario.Visible = true;
                    Salario.Visible = true;
                    lbl_TaxaComissao.Visible = true;
                    TaxaComissao.Visible = true;
                    taxacomissao_Obrigado.Visible = true;
                    salario_obrigado.Visible = true;
                    
                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
            finally
            {
                unfreeze();
            }

        }

        private async void Horista_CheckedChanged(object sender, EventArgs e)
        {
            freeze();
            try
            {
                if (Horista.Checked)
                {
                    if (string.IsNullOrEmpty(FuncionariosId.Text))
                    {
                        var result = await new Services<AgendaPagamento>().Get("api/AgendaPagamento");

                        foreach (var item in result)
                        {
                            if (item.Agenda == "Semanal - Sexta-Feira")
                            {
                                AgendaId.TxtCodigo.Text = item.AgendaId.ToString();
                                AgendaId.TxtDescricao.Text = item.Agenda;
                            }
                        }
                    }

                    Comissionado.Checked = false;
                    Assalariado.Checked = false;

                    lbl_TaxaComissao.Visible = false;
                    TaxaComissao.Visible = false;

                    Salario.Visible = false;
                    lbl_Salario.Visible = false;

                    taxacomissao_Obrigado.Visible = false;

                    ValorHora.Visible = true;
                    lbl_ValorHora.Visible = true;
                    salario_obrigado.Visible = true;
                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
            finally
            {
                unfreeze();
            }            
        }

        private async void btn_Buscar_Click(object sender, EventArgs e)
        {
            freeze();
            try
            {
                var keyword = PalavraChave.Text;
                if (string.IsNullOrEmpty(PalavraChave.Text))
                {
                    keyword = "*";
                }

                var funcionarios = await new Services<FuncionarioVw>().Get("api/funcionarios/");

                for (int i = 0; i < funcionarios.Count; i++)
                {
                    if (funcionarios[i].TipoFuncionario == 1)
                    {
                        funcionarios[i].Tipo = "Assalariado";
                    }
                    if (funcionarios[i].TipoFuncionario == 2)
                    {
                        funcionarios[i].Tipo = "Comissionado";
                    }
                    if (funcionarios[i].TipoFuncionario == 3)
                    {
                        funcionarios[i].Tipo = "Horista";
                    }
                }

                GridConsultaP.LoadFromList(funcionarios);
            }
            catch (Exception M)
            {

                MessageBox.Show(M.Message);
            }
            finally
            {
                unfreeze();
            }

        }

        private void FuncionarioSindicalId_ConsultarClick(object sender, EventArgs e)
        {
            var frmConsulta = new SindicatoConsulta();
            frmConsulta.Owner = this;
            frmConsulta.ShowDialog();
            if (!string.IsNullOrEmpty(FuncionarioSindicalId.TxtDescricao.Text))
            {
                lbl_TxSindical.Visible = true;
                TaxaSindical.Visible = true;
                sindical_obrigado.Visible = true;
            }
        }

        private void AgendaId_ConsultarClick(object sender, EventArgs e)
        {
            var frmConsulta = new AgendaConsulta();
            frmConsulta.Owner = this;
            frmConsulta.ShowDialog();
        }

        private void FuncionarioSindicalId_ConsultarAPI(object sender) { }

        private void AgendaId_ConsultarAPI(object sender){}

        private async void btn_Excluir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja realmente excluir este funcionário?\nToda informação pertencente a ele será excluida, como:\nRegistro de Ponto\nRegistro de Vendas\nMatrícula no Sindicato\n", "Exclusão Funcionário", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)== DialogResult.Yes)
            {
                var result = await new Services<Funcionario>().Delete("api/funcionarios", FuncionariosId.Text);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Excluido com Sucesso");
                    LimpaCadastro();
                }
            }            
        }

        private void CleanSindicato_CheckedChanged(object sender, EventArgs e)
        {
            FuncionarioSindicalId.Clear();
            TaxaSindical.Clear();
            TaxaSindical.Visible = false;
            sindical_obrigado.Visible = false;
            lbl_TxSindical.Visible = false;
            CleanSindicato.Checked = false;
        }
    }
}
