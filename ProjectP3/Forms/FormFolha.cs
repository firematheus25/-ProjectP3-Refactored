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
    public partial class FormFolha : FormPadrao
    {
        public List<Folha> ListFolha;
        public FormFolha()
        {
            InitializeComponent();

            GridFolha.BuilderColumn("funcionariosId", "Matrícula", 65);
            GridFolha.BuilderColumn("Nome", "Nome", DataGridViewAutoSizeColumnMode.Fill);
            GridFolha.BuilderColumn("MetodoPagamento", "Metodo Pagamento", DataGridViewAutoSizeColumnMode.Fill);
            GridFolha.BuilderColumn("Salario", "Salário", DataGridViewAutoSizeColumnMode.Fill, "R$ 0,00.00");
            GridFolha.BuilderColumn("DtPagamento", "Pagamento", DataGridViewAutoSizeColumnMode.None, "dd/MM/yyyy");


            GridConsultaP.BuilderColumn("funcionariosId", "Matrícula", 65);
            GridConsultaP.BuilderColumn("Nome", "Nome", DataGridViewAutoSizeColumnMode.Fill);
            GridConsultaP.BuilderColumn("MetodoPagamento", "Metodo Pagamento", DataGridViewAutoSizeColumnMode.Fill);
            GridConsultaP.BuilderColumn("Salario", "Salário", DataGridViewAutoSizeColumnMode.Fill, "R$ 0,00.00");
            GridConsultaP.BuilderColumn("DtPagamento", "Pagamento", DataGridViewAutoSizeColumnMode.None, "dd/MM/yyyy");

            this.GridConsultaP.Size = new System.Drawing.Size(531, 397); 


            ListFolha = new List<Folha>();
        }


        private async void GerarFolha_Click(object sender, EventArgs e)
        {
            if (DtPagamento.Date == null)
            {
                MessageBox.Show("Informe uma data de pagamento.");
                return;
            }
            GridFolha.Rows.Clear();
            ListFolha.Clear();

            freeze();
            try
            {

                var List = await new Services<Folha>().Get("api/folha");

                foreach (var item in List)
                {
                    if (item.DtPagamento == DtPagamento.Date)
                    {
                        MessageBox.Show("Folha já gerada nesta data.");
                        return;
                    }
                }


                var Funcionario = await new Services<FuncionarioVw>().Get("api/Funcionarios/");

                string DIASEMANA = "";
                if (DtPagamento.Date.Value.DayOfWeek.ToString() == "Sunday") { DIASEMANA = "Domingo"; }
                if (DtPagamento.Date.Value.DayOfWeek.ToString() == "Monday") { DIASEMANA = "Segunda-Feira"; }
                if (DtPagamento.Date.Value.DayOfWeek.ToString() == "Tuesday") { DIASEMANA = "Terça-Feira"; }
                if (DtPagamento.Date.Value.DayOfWeek.ToString() == "Wednesday") { DIASEMANA = "Quarta-Feira"; }
                if (DtPagamento.Date.Value.DayOfWeek.ToString() == "Thursday") { DIASEMANA = "Quinta-Feira"; }
                if (DtPagamento.Date.Value.DayOfWeek.ToString() == "Friday") { DIASEMANA = "Sexta-Feira"; }
                if (DtPagamento.Date.Value.DayOfWeek.ToString() == "Saturday") { DIASEMANA = "Sábado"; }


                var ultimoDiaDoMes = new DateTime(DtPagamento.Date.Value.Year, DtPagamento.Date.Value.Month, DateTime.DaysInMonth(DtPagamento.Date.Value.Year, DtPagamento.Date.Value.Month));


                DateTime DataMes;
                if (DtPagamento.Date.Value.Day.ToString() == "31")
                {
                    DataMes = new DateTime(DtPagamento.Date.Value.Year, (DtPagamento.Date.Value.Month - 1), (DtPagamento.Date.Value.Day - 1));
                }
                else
                {
                    DataMes = new DateTime(DtPagamento.Date.Value.Year, (DtPagamento.Date.Value.Month - 1), (DtPagamento.Date.Value.Day));
                    //DataMes = DataMes.AddDays(1);
                }


                for (int i = 0; i < Funcionario.Count; i++)
                {
                    var X = Funcionario[i];
                    double? salario = 0;

                    if (Funcionario[i].Agenda == "Mensal $")
                    {
                        Funcionario[i].Dia = ultimoDiaDoMes.Day.ToString();
                    }


                    var TaxaServicoSindical = await new Services<TaxasServico>().GetByIds("api/TaxasServico/Ids", Funcionario[i].FuncionarioSindicalId.ToString());

                    if (Funcionario[i].TipoAgenda == "Mensal") //MENSAL
                    {

                        if (Funcionario[i].Dia == DtPagamento.Date.Value.Day.ToString())
                        {

                            if (Funcionario[i].TipoFuncionario == 1) //Assalariado
                            {                                

                                salario = X.Salario;

                                if (!string.IsNullOrEmpty(Funcionario[i].SindicatosId.ToString()))
                                {
                                    var taxa = Funcionario[i].TaxaSindical;
                                    salario = salario - taxa;
                                }

                                salario = CalcTaxaServico(TaxaServicoSindical, (double)salario, ultimoDiaDoMes, ultimoDiaDoMes.Day);
                            }


                            if (Funcionario[i].TipoFuncionario == 2) // Comissionado
                            {                                
                               
                                if (!string.IsNullOrEmpty(Funcionario[i].SindicatosId.ToString()))
                                {
                                    var taxa = Funcionario[i].TaxaSindical;
                                    salario = X.SalarioComissao - taxa;
                                }

                                salario = CalcTaxaServico(TaxaServicoSindical, (double)salario, ultimoDiaDoMes, ultimoDiaDoMes.Day);


                                var vendas = await new Services<Vendas>().GetByIds("api/Vendas/Ids", Funcionario[i].FuncionariosId.ToString());

                                if (vendas != null)
                                {
                                    for (int v = 0; v < vendas.Count; v++)
                                    {
                                        if (vendas[v].DtVenda.Date > DataMes.Date && vendas[v].DtVenda.Date <= DtPagamento.Date)
                                        {
                                            salario += salario + vendas[v].Comissao;
                                        }
                                    }
                                }
                            }


                            if (Funcionario[i].TipoFuncionario == 3) //Horista
                            {
                                var RegistroPontos = await new Services<RegistroPonto>().GetByIds("api/RegistroPontos/Ids", Funcionario[i].FuncionariosId.ToString());
                                salario = 0;

                                salario = CalcHoras(RegistroPontos, salario, X, 0, DataMes);

                                if (!string.IsNullOrEmpty(Funcionario[i].SindicatosId.ToString()))
                                {
                                    var taxa = Funcionario[i].TaxaSindical;
                                    salario = salario - taxa;
                                }

                                salario = CalcTaxaServico(TaxaServicoSindical, (double)salario, ultimoDiaDoMes, ultimoDiaDoMes.Day);
                            }
                        }
                    }

                    if (Funcionario[i].TipoAgenda == "Semanal") //SEMANAL
                    {
                        if (Funcionario[i].DiaSemana == DIASEMANA)
                        {
                            if (Funcionario[i].TipoFuncionario == 1) //ASSALARIADO
                            {                                
                                salario = (X.Salario / ultimoDiaDoMes.Date.Day) * 7;

                                if (!string.IsNullOrEmpty(Funcionario[i].SindicatosId.ToString()))
                                {
                                    var taxa = Funcionario[i].TaxaSindical;
                                    var taxasemanal = (taxa / ultimoDiaDoMes.Date.Day) * 7;
                                    salario = salario - taxasemanal;
                                }

                                salario = CalcTaxaServico(TaxaServicoSindical, (double)salario, ultimoDiaDoMes, 7);
                            }

                            if (Funcionario[i].TipoFuncionario == 2) // Comissionado
                            {
                                
                                salario = (X.SalarioComissao / ultimoDiaDoMes.Date.Day) * 7;
                                salario = Math.Round((double)salario, 2);

                                if (!string.IsNullOrEmpty(Funcionario[i].SindicatosId.ToString()))
                                {
                                    var taxa = Funcionario[i].TaxaSindical;
                                    var taxasemanal = (taxa / ultimoDiaDoMes.Date.Day) * 7;
                                    salario = salario - taxasemanal;
                                }

                                salario = CalcTaxaServico(TaxaServicoSindical, (double)salario, ultimoDiaDoMes, 7);


                                var vendas = await new Services<Vendas>().GetByIds("api/Vendas/Ids", Funcionario[i].FuncionariosId.ToString());


                                if (vendas != null)
                                {
                                    for (int v = 0; v < vendas.Count; v++)
                                    {
                                        var Day = DtPagamento.Date.Value.AddDays(-6);

                                        if (vendas[v].DtVenda.Date > Day.Date && vendas[v].DtVenda.Date <= DtPagamento.Date)
                                        {
                                            salario += vendas[v].Comissao;
                                        }
                                    }
                                }                                
                            }

                            if (Funcionario[i].TipoFuncionario == 3) // Horista
                            {
                                var RegistroPontos = await new Services<RegistroPonto>().GetByIds("api/RegistroPontos/Ids", Funcionario[i].FuncionariosId.ToString());
                                salario = 0;

                                salario = CalcHoras(RegistroPontos, salario, X, -6, DataMes);


                                if (!string.IsNullOrEmpty(Funcionario[i].SindicatosId.ToString()))
                                {
                                    var taxa = Funcionario[i].TaxaSindical;
                                    var taxasemanal = (taxa / ultimoDiaDoMes.Date.Day) * 7;
                                    salario = salario - taxasemanal;
                                }


                                 salario = CalcTaxaServico(TaxaServicoSindical, (double)salario, ultimoDiaDoMes, 7);

                            }
                        }
                    }


                    bool validacao = true;
                    foreach (var item in List)
                    {
                        if (item.FuncionariosId == Funcionario[i].FuncionariosId)
                        {
                            var date = DtPagamento.Date.Value.AddDays(-7);
                            if (date.Date == item.DtPagamento)
                            {
                                validacao = false;
                            }
                        }
                    }
                    if (Funcionario[i].TipoAgenda == "Bi-semanal") // BI-SEMANAL
                    {

                        if (Funcionario[i].DiaSemana == DIASEMANA)
                        {

                            if (Funcionario[i].TipoFuncionario == 1) //ASSALARIADO
                            {

                                if (validacao)
                                {
                                    salario = (X.Salario / ultimoDiaDoMes.Date.Day) * 14;


                                    if (!string.IsNullOrEmpty(Funcionario[i].SindicatosId.ToString()))
                                    {
                                        var taxa = Funcionario[i].TaxaSindical;
                                        var taxasemanal = (taxa / ultimoDiaDoMes.Date.Day) * 14;
                                        salario = salario - taxasemanal;
                                    }

                                    salario = CalcTaxaServico(TaxaServicoSindical, (double)salario, ultimoDiaDoMes, 14);

                                }

                            }

                            if (Funcionario[i].TipoFuncionario == 2) //Comissionado
                            {
                                if (validacao)
                                {
                                    salario = (X.SalarioComissao / ultimoDiaDoMes.Date.Day) * 14;
                                    salario = Math.Round((double)salario, 2);



                                    if (!string.IsNullOrEmpty(Funcionario[i].SindicatosId.ToString()))
                                    {
                                        var taxa = Funcionario[i].TaxaSindical;
                                        var taxasemanal = (taxa / ultimoDiaDoMes.Date.Day) * 14;
                                        salario = salario - taxasemanal;
                                    }

                                    salario = CalcTaxaServico(TaxaServicoSindical, (double)salario, ultimoDiaDoMes, 14);


                                    var vendas = await new Services<Vendas>().GetByIds("api/Vendas/Ids", Funcionario[i].FuncionariosId.ToString());


                                    if (vendas != null)
                                    {
                                        for (int v = 0; v < vendas.Count; v++)
                                        {
                                            var Day = DtPagamento.Date.Value.AddDays(-13);

                                            if (vendas[v].DtVenda.Date > Day.Date && vendas[v].DtVenda.Date <= DtPagamento.Date)
                                            {
                                                salario += vendas[v].Comissao;
                                            }
                                        }
                                    }
                                }
                            }

                            if (Funcionario[i].TipoFuncionario == 3) //Horista
                            {
                                if (validacao)
                                {
                                    var RegistroPontos = await new Services<RegistroPonto>().GetByIds("api/RegistroPontos/Ids", Funcionario[i].FuncionariosId.ToString());
                                    salario = 0;

                                    salario = CalcHoras(RegistroPontos, salario, X, -13, DataMes);

                                    if (!string.IsNullOrEmpty(Funcionario[i].SindicatosId.ToString()))
                                    {
                                        var taxa = Funcionario[i].TaxaSindical;
                                        var taxasemanal = (taxa / ultimoDiaDoMes.Date.Day) * 14;
                                        salario = salario - taxasemanal;
                                    }
                                    salario = CalcTaxaServico(TaxaServicoSindical, (double)salario, ultimoDiaDoMes, 14);
                                }
                            }

                        }                        
                    }
                    if (salario != 0)
                    {
                        AgruparFolha(X, (double)salario);
                    }                   
                }

                GridFolha.LoadFromList(ListFolha);

                if (ListFolha.Count == 0)
                {
                    MessageBox.Show("Nenhum pagamento para esta data");
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

        public void AgruparFolha(FuncionarioVw X, double Salario)
        {
            var folha = new Folha();
            folha.FuncionariosId = X.FuncionariosId;
            folha.Nome = X.Nome;
            if (X.MetodoPagamento == 1)
            {
                folha.MetodoPagamento = "Cheque pelos correios";
            }
            if (X.MetodoPagamento == 2)
            {
                folha.MetodoPagamento = "Cheque em mãos";
            }
            if (X.MetodoPagamento == 3)
            {
                folha.MetodoPagamento = "Deposito em conta bancária";
            }
            folha.DtPagamento = DtPagamento.Date.Value;
            folha.Salario = Math.Round((double)Salario, 2);
            ListFolha.Add(folha);
        }

        public double CalcTaxaServico(List<TaxasServico> TaxaServicoSindical, double salario, DateTime ultimoDiaDoMes, int Condicao)
        {
            if (TaxaServicoSindical != null)
            {
                if (TaxaServicoSindical.Count > 0)
                {
                    for (int n = 0; n < TaxaServicoSindical.Count; n++)
                    {
                        if (TaxaServicoSindical[n].Competencia.Month == DtPagamento.Date.Value.Month)
                        {
                            var taxasemanal = (TaxaServicoSindical[n].TaxaServico / ultimoDiaDoMes.Date.Day) * Condicao;

                            salario = salario - taxasemanal;
                        }
                    }
                    return salario;
                }
            }
            return salario;
        }

        public double CalcHoras(List<RegistroPonto> RegistroPontos, double? salario, FuncionarioVw X, double dias, DateTime DataMes)
        {
            for (int j = 0; j < RegistroPontos.Count; j++)
            {
                var Y = RegistroPontos[j];
                var Day = DtPagamento.Date.Value.AddDays(dias);
                if (dias == 0)
                {
                    Day = DataMes.Date;
                }
                if (Y.DtPonto.Value.Date > Day.Date && Y.DtPonto.Value.Date <= DtPagamento.Date)
                {
                    var HS = Convert.ToDateTime(Y.Horas);
                    TimeSpan padrao = new TimeSpan(08, 00, 00);

                    var Horas = HS.Hour;
                    var Minuto = HS.Minute;
                    var ValorMin = (HS.Minute * 1.666667) / 100;
                    var ValorMinu = X.ValorHora * ValorMin;
                    var ValorMinConvertido = Math.Round((double)ValorMinu, 2);

                    var HoraExtra = HS.TimeOfDay - padrao; // Quantidade de Horas/Minutos Extras
                    var Horacalc = HoraExtra.Hours;        // Quantidade de Horas Extras
                    var Mincalc = (HoraExtra.Minutes * 1.666667) / 100; // Quantidade de Minutos Extras
                    var TaxaExtra = ((double)(X.ValorHora * 1.5)); // Valor Taxa Extra
                    var Min = TaxaExtra * Mincalc; // Valor Minutos Extras
                    var MinExtra = Math.Round(Min, 2); // Valor Minutos Extras - Duas casas Decimais

                    if (HS.TimeOfDay > padrao)
                    {

                        salario += (X.ValorHora * padrao.Hours) + (TaxaExtra * Horacalc) + MinExtra;
                    }
                    else
                    {
                        salario += (X.ValorHora * Horas) + ValorMinConvertido;
                    }
                }
            }
            return (double)salario;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            freeze();
            try
            {
                var Folha = new FolhaEspelho();
                Folha.ListFolha = ListFolha;

                var result = await new Services<FolhaEspelho>().Post("api/folhaespelho", Folha);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Inserido com sucesso.");

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

        private async  void btn_Buscar_Click(object sender, EventArgs e)
        {
            var List =  await new Services<Folha>().Get("api/folha");

            GridConsultaP.LoadFromList(List);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCadastro();
        }

        public override void LimpaCadastro()
        {
            DtPagamento.Clear();
            GridFolha.Rows.Clear();
        }
    }
}
