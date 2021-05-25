using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{
    [Table("TaxaServico")]
    public class TaxasServico
    {
        [Key]
        public int TaxaServicoId { get; set; }
        public int FuncionarioSindicalId { get; set; }
        public string Nome { get; set; }
        public DateTime Competencia { get; set; }
        public double TaxaServico { get; set; }
    }
}
