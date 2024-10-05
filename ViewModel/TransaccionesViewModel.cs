using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRemesas.Models;

namespace AppRemesas.ViewModel
{
    public class TransaccionesViewModel
    {
        public Transacciones? FormTransacciones { get; set; } 
        public IEnumerable<Transacciones>? ListTransacciones { get; set; } 
    }
}