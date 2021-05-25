using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miscellaneous.Models
{
    [Table("RegistroPontos")]
    public class RegistroPonto
    {
        [Key]
        public int RegistroPontoId { get; set; }
        public int FuncionariosId { get; set; }
        public string Nome { get; set; }
        public DateTime? DtPonto { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public string Horas { get; set; }

    }
}
