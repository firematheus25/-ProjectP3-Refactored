using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{
    [Table("Folhas")]
    public class Folha
    {
        [Key]
        public int FolhasId { get; set; }
        public int FuncionariosId { get; set; }
        public string Nome { get; set; }
        public DateTime DtPagamento { get; set; }
        public double? Salario { get; set; }
        public string MetodoPagamento { get; set; }

        //public List<Folha> ListFolha { get; set; }

    }
}
