using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Data;
using Ruleta.Models;

namespace Ruleta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateRuletaController : ControllerBase
    {
        private readonly AppDbContext context;
        public CreateRuletaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Ruleta.Models.Ruleta ruletas)
        {
            try 
            {
                context.Ruleta.Add(ruletas);
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }

    
}
