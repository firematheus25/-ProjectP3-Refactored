using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{
    public class ConsultaComissionado : IConsultaFuncionario
    {
        ConsultaFuncionario Funcionario;

        public  ConsultaComissionado(ConsultaFuncionario Funcionario)
        {
            this.Funcionario = Funcionario;
        }
            
        public void Executar()
        {
            //Funcionario
        }
    }
}
