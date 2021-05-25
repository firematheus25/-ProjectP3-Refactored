using miscellaneous.Models;
using ProjectP3.MDI;
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

namespace ProjectP3.Forms.FormConsulta
{
    public partial class FuncionariosConsulta : FormConsult
    {
        public FuncionariosConsulta()
        {
            InitializeComponent();


            GridConsulta.BuilderColumn("funcionariosId", "Matrícula");
            GridConsulta.BuilderColumn("Nome", "Nome", DataGridViewAutoSizeColumnMode.Fill);
        }

        public async override void FormConsulta_Load(object sender, EventArgs e)
        {

            try
            {
                List<Funcionario> ListFuncionarios;
                var t = this.Owner.GetType();
                if (t.Equals(typeof(FormRegistroPonto)))
                {
                    ListFuncionarios = await new Services<Funcionario>().Get("api/Horista/Horistas");
                }
                else if (t.Equals(typeof(FormVendas)))
                {
                    ListFuncionarios = await new Services<Funcionario>().Get("api/Comissionado/Comissionados");
                }
                else
                {
                    ListFuncionarios = null;
                }



                GridConsulta.LoadFromList(ListFuncionarios);

            }
            catch (Exception M)
            {

                MessageBox.Show(M.Message);
            }
           
        }

        public async override void GridConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

                var Id = GridConsulta.CurrentRow.Cells["FuncionariosId"].Value.ToString();
                var funcionario = await new Services<FuncionarioVw>().GetById("api/funcionarios/Id", Id);

            var t = this.Owner.GetType();
            if (t.Equals(typeof(FormRegistroPonto)))
            {
                var frm = (FormRegistroPonto)this.Owner;
                frm.FuncionariosId.TxtCodigo.Text = Convert.ToString(funcionario.FuncionariosId);
                frm.FuncionariosId.TxtDescricao.Text = funcionario.Nome;
                this.Close();
            }
            if (t.Equals(typeof(FormVendas)))
            {
                var frm = (FormVendas)this.Owner;
                frm.FuncionariosId.TxtCodigo.Text = Convert.ToString(funcionario.FuncionariosId);
                frm.FuncionariosId.TxtDescricao.Text = funcionario.Nome;
                frm.PorcentagemVenda.Valor = (decimal?)funcionario.TaxaComissao;
                this.Close();
            }

            this.Close();

        }
    }
}
