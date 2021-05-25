using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{

    [Table("Sindicatos")]
    public class Sindicato
    {
        [Key]
        public int SindicatosId { get; set; }
        public string Nome { get; set; }


    }
}
