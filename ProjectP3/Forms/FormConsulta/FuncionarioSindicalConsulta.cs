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
    public partial class FuncionarioSindicalConsulta : FormConsult
    {
        public FuncionarioSindicalConsulta()
        {
            InitializeComponent();

            GridConsulta.BuilderColumn("FuncionarioSindicalId", "Matrícula Sindicato");
            GridConsulta.BuilderColumn("Nome","Funcionário", DataGridViewAutoSizeColumnMode.Fill);
        }

        public async override void FormConsulta_Load(object sender, EventArgs e)
        {

            var ListSindicato = await new Services<FuncionarioSindical>().Get("api/FuncionariosSindicais");
            GridConsulta.LoadFromList(ListSindicato);
        }

        public async override void GridConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var IdSind = GridConsulta.CurrentRow.Cells["funcionarioSindicalId"].Value.ToString();
            var Sindicato = await new Services<FuncionarioSindical>().GetById("api/FuncionariosSindicais/Id", IdSind);

            var frmSind = (FormTaxas)this.Owner;

            frmSind.FuncionariosId.TxtCodigo.Text = Convert.ToString(Sindicato.FuncionarioSindicalId);
            frmSind.FuncionariosId.TxtDescricao.Text = Sindicato.Nome;

            this.Close();

        }


    }
}
