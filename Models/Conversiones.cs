using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppRemesas.Models
{
    [Table("t_Conversiones")]
    public class Conversiones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; } 

        public string? MonedaOrigen { get; set; } 

        public string? MonedaDestino { get; set; } 

        public decimal? TasaCambio { get; set; } 

        public DateTime FechaConversion { get; set; }
    }
}