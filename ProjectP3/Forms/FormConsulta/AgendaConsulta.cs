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
    public partial class AgendaConsulta : FormConsult
    {
        public AgendaConsulta()
        {
            InitializeComponent();
            GridConsulta.BuilderColumn("AgendaId");
            GridConsulta.BuilderColumn("Agenda", "Agenda", DataGridViewAutoSizeColumnMode.Fill);

        }

        public async override void FormConsulta_Load(object sender, EventArgs e)
        {
            try
            {
                var Agenda = await new Services<AgendaPagamento>().Get("api/AgendaPagamento");

                Agenda = Agenda.OrderBy(x => x.Dia).ToList();
                GridConsulta.LoadFromList(Agenda);
            }
            catch (Exception M)
            {

                MessageBox.Show(M.Message);
            }
            
        }

        public async override void GridConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {          
            var Id = GridConsulta.CurrentRow.Cells["AgendaId"].Value.ToString();
            var Agenda = await new Services<AgendaPagamento>().GetById("api/AgendaPagamento/Id", Id);

            var frm = (FormFuncionario)this.Owner;

            frm.AgendaId.TxtCodigo.Text = Convert.ToString(Agenda.AgendaId);
            frm.AgendaId.TxtDescricao.Text = Agenda.Agenda;
            this.Close();
        }
    }
}
