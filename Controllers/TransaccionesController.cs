using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppRemesas.Data;
using AppRemesas.Models;
using AppRemesas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppRemesas.Controllers
{
    
    public class TransaccionesController : Controller
    {
        private readonly ILogger<TransaccionesController> _logger;
        private readonly ApplicationDbContext _context;

        public TransaccionesController(ILogger<TransaccionesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
       
        public IActionResult Index()
        {
            var misTransacciones = _context.Transacciones.ToList();
            _logger.LogDebug("Transacciones:{misTransacciones}",misTransacciones);
            var viewModel = new TransaccionesViewModel
            {
                FormTransacciones= new Transacciones(),
                ListTransacciones=misTransacciones
            };

            _logger.LogDebug("ViewModel: {viewModel}", viewModel);
            return View(viewModel);
        }



        [HttpPost]
        public IActionResult Registrar(TransaccionesViewModel viewModel)
        {
            var fechaTransaccion = viewModel.FormTransacciones.FechaTransaccion.ToUniversalTime();
            var transacciones = new Transacciones
            {

                NombreRemitente = viewModel.FormTransacciones.NombreRemitente,
                NombreDestinatario = viewModel.FormTransacciones.NombreDestinatario,
                PaisOrigen = viewModel.FormTransacciones.PaisOrigen,
                PaisDestino = viewModel.FormTransacciones.PaisDestino,
                MontoEnviado = viewModel.FormTransacciones.MontoEnviado,
                Moneda  = viewModel.FormTransacciones.Moneda ,
                TasaCambio = viewModel.FormTransacciones.TasaCambio,
                MontoFinal = viewModel.FormTransacciones.MontoFinal,
                Estado = viewModel.FormTransacciones.Estado ,
                FechaTransaccion = fechaTransaccion
            };

            _context.Transacciones.Add(transacciones);
            _context.SaveChanges();

            ViewData["Message"] = "Transacción Registrada";

            var misTransacciones = _context.Transacciones.ToList();
            viewModel.ListTransacciones = misTransacciones;

            return View("Index", viewModel);
        }

        public IActionResult Lista()
        {
            var misTransacciones= _context.Transacciones.ToList(); 
            var viewModel = new TransaccionesViewModel
            {
                ListTransacciones = misTransacciones
            };

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}