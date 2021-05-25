using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{   
    [Table("Assalariados")]
    public class Assalariado
    {

        [Key]
        public int AssalariadoId { get; set; }
        public int FuncionariosId { get; set; }
        public double Salario { get; set; }

    }
}
