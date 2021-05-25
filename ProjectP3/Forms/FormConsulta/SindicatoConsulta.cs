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
    public partial class SindicatoConsulta : FormConsult
    {
        public SindicatoConsulta()
        {
            InitializeComponent();

            GridConsulta.BuilderColumn("SindicatosId");
            GridConsulta.BuilderColumn("Nome", "Sindicato", DataGridViewAutoSizeColumnMode.Fill);


        }

        public async override void FormConsulta_Load(object sender, EventArgs e)
        {

                var ListSindicato = await new Services<Sindicato>().Get("api/Sindicatos");
                GridConsulta.LoadFromList(ListSindicato);
        }

        public async override void GridConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var IdSind = GridConsulta.CurrentRow.Cells["SindicatosId"].Value.ToString();
            var Sindicato = await new Services<Sindicato>().GetById("api/Sindicatos/Id", IdSind);

            var frmSind = (FormFuncionario)this.Owner;

            frmSind.FuncionarioSindicalId.TxtCodigo.Text = Convert.ToString(Sindicato.SindicatosId);
            frmSind.FuncionarioSindicalId.TxtDescricao.Text = Sindicato.Nome;

            this.Close();

        }
    }
}
