using CaronteCore.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronteCore.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public int? IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
    }
}
