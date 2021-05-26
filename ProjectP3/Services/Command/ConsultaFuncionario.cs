using miscellaneous.Models;
using ProjectP3.Forms.FormConsulta;
using ProjectP3.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP3.Services
{
    public class ConsultaFuncionario
    {
        List<Funcionario> ListFuncionarios;

        public ConsultaFuncionario()
        {

        }

        public async Task<List<Funcionario>> Horista()
        {
           return ListFuncionarios = await new Services<Funcionario>().Get("api/Horista/Horistas");
        }

        public async Task<List<Funcionario>> Comissionado()
        {
            return ListFuncionarios = await new Services<Funcionario>().Get("api/Comissionado/Comissionados");
        }

    }
}
