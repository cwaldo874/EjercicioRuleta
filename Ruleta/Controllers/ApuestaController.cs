using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Data;
using Ruleta.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EjercicioRuleta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApuestaController : ControllerBase
    {
        private readonly AppDbContext context;
        public ApuestaController(AppDbContext context)
        {
            this.context = context;
        }

        // POST api/<ApuestaController>
        [HttpPost]
        public String Post([FromBody] Apuesta apuesta)
        {
            apuesta.state = "Perdedor";
            string message = "";
            try
            {
                var Ruletas = context.Ruleta.FirstOrDefault(p => p.Id == apuesta.IdRuleta);
                if (Ruletas.estado.Equals("abierta"))
                {
                    if (apuesta.number < 0 && apuesta.number > 36)
                    {
                        message = "el numero apostar debe estar entre 0 y 36";
                    }
                    else 
                    {
                        if (apuesta.Color.Equals("negro") || apuesta.Color.Equals("rojo"))
                        {
                            context.Apuesta.Add(apuesta);
                            context.SaveChanges();
                        }
                        else 
                        {
                            message = "el Color debe ser negro o Rojo";
                        }
                    }              
                }
                else
                {
                    message= "La ruleta ya se encuentra cerrada no puede realizar la apuesta";
                }
                return message;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
