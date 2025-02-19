using System.ComponentModel.DataAnnotations;

namespace L01_2022PD651_2022VZ650.Models
{
    public class platos
    {
        [Key]
        public int platoId { get; set; }
        public string nombrePlato { get; set; }
        public decimal precio { get; set; }

    }
}
