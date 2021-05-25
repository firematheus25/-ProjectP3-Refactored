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
    public partial class FormConsultaPadraoFuncionario : FormConsultaPadrao
    {
        public FormConsultaPadraoFuncionario()
        {
            InitializeComponent();

            GridConsulta.BuilderColumn("funcionariosId", "Matrícula");
            GridConsulta.BuilderColumn("Nome", "Nome", DataGridViewAutoSizeColumnMode.Fill);
            GridConsulta.BuilderColumn("TipoFuncionario", "Tipo", DataGridViewAutoSizeColumnMode.Fill);                        

        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PalavraChave.Text))
            {
                MessageBox.Show("Prencha 'Palavra Chave'");
                PalavraChave.Focus();

            }
            else
            {
             //  var Funcionarios = await new Services<Funcio>
            }

        }

        private async void GridConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = GridConsulta.CurrentRow.Cells["FuncionariosId"].Value.ToString();
            var funcionario = await new Services<Funcionario>().GetById("api/funcionarios/", id);

            var frm = (FormFuncionario)this.Owner;

            



        }

        private async void ConsultaFuncionario_Load(object sender, EventArgs e)
        {
            var ListFuncionarios = await new Services<Funcionario>().Get("api/Funcionarios/");

            if (true)
            {

            }

            GridConsulta.LoadFromList(ListFuncionarios);

        }
    }
}
