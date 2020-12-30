using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Data;

namespace EjercicioRuleta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetRuletaController : ControllerBase
    {
        private readonly AppDbContext context;
        public GetRuletaController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Ruleta.Models.Ruleta> Get()
        {
            return context.Ruleta.ToList();
        }

        [HttpGet("{id}")]
        public Ruleta.Models.Ruleta Get(String id)
        {
            var Ruletas = context.Ruleta.FirstOrDefault(p => p.Id == int.Parse(id));
            return Ruletas;
        }
    }
}
