using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : ControllerBase
    {
        private static readonly string[] Nombres = new[]
        {
            "Campera Adidas", "Gorra Adidas", "Camiseta Boca"
        };

        private static readonly string[] Talles = new[]
        {
            "S", "M", "L", "XL"
        };
        
        [HttpGet]
        public IEnumerable<Catalogo> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Catalogo
                {
                    Nombre = Nombres[rng.Next(Nombres.Length)],
                    Talle = Talles[rng.Next(Talles.Length)],
                })
            .ToArray();
        }
    }
}
