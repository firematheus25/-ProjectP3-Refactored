using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{
    [Table("Comissionados")]
    public class Comissionado 
    {
        [Key]
        public int ComissionadoId { get; set; }
        public int FuncionariosId { get; set; }
        public decimal Salario { get; set; }
        public decimal TaxaComissao { get; set; }

    }
}
