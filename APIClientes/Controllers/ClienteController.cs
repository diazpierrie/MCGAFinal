using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private static readonly string[] Nombres = new[]
        {
            "Juan", "Ricardo", "Jose", "Alejandro"
        };


        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Cliente
                {
                    Nombre = Nombres[rng.Next(Nombres.Length)],
                    Edad = rng.Next(18, 70)
                })
            .ToArray();
        }
    }
}
