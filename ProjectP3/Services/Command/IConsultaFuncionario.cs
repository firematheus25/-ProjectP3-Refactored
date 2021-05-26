using miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP3.Services
{
    public interface IConsultaFuncionario
    {
        Task<List<Funcionario>> Executar();
    }
}
