using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaronteCore.Models.DTO
{
    public class GraficoDonutDTO
    {
        public int CategoriaId { get; set; }
        public string CategoriaDescricao { get; set; }
        public decimal Total { get; set; }
    }
}
