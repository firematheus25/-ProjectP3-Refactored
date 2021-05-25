using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{
    [Table("AgendaPagamentos")]
    public class AgendaPagamento
    {
        [Key]
        public int AgendaId { get; set; }
        public string Tipo { get; set; }
        public string Dia { get; set; }
        public string DiaSemana { get; set; }
        public string Agenda { get; set; }
    }
}
