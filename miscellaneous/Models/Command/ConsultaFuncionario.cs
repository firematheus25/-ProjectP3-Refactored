using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{
    public class ConsultaFuncionario
    {
        List<Funcionario> ListFuncionarios;

        public ConsultaFuncionario()
        {

        }

        public async void Horista()
        {
            ListFuncionarios = await new Services<Funcionario>().Get("api/Horista/Horistas");
        }
    }
}
