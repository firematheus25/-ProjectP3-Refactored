using miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP3.Services
{
    public class ConsultaComissionado : IConsultaFuncionario
    {
        ConsultaFuncionario Funcionario;

        public  ConsultaComissionado(ConsultaFuncionario Funcionario)
        {
            this.Funcionario = Funcionario;
        }
            
        public async Task<List<Funcionario>> Executar()
        {
            return await Funcionario.Comissionado();
        }
    }
}
