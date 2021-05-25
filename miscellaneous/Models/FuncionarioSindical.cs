using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{
    public class FuncionarioSindical
    {
        public int? FuncionarioSindicalId { get; set; }
        public int? FuncionariosId { get; set; }
        public string Nome { get; set; }
        public int? SindicatosId { get; set; }
        public double? TaxaSindical { get; set; }

    }
}
