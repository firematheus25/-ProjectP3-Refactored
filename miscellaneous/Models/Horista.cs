using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{
    [Table("Horistas")]
    public class Horista 
    {
        [Key]
        public int HoristaId { get; set; }
        public int FuncionariosId { get; set; }
        public double ValorHora { get; set; }
    }
}
