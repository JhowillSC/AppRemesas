using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppRemesas.Models
{
    [Table("t_Transacciones")]
    public class Transacciones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long Id { get; set; } 

        public string? NombreRemitente { get; set; } 

        public string? NombreDestinatario { get; set; } 

        public string? PaisOrigen { get; set; } 

        public string? PaisDestino { get; set; } 

        public decimal? MontoEnviado { get; set; } 

        public string? Moneda { get; set; } 

        public decimal? TasaCambio { get; set; } 

        public decimal? MontoFinal { get; set; } 

        public string? Estado { get; set; } 

        public DateTime FechaTransaccion { get; set; } 
    }
}