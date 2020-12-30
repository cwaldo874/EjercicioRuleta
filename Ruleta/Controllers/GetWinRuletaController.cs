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
    public class GetWinRuletaController : ControllerBase
    {
        private readonly AppDbContext context;
        public GetWinRuletaController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public IEnumerable<Apuesta> Post([FromBody] Ruleta.Models.Ruleta ruleta)
        {
            ruleta.estado = "cerrada";
            context.Ruleta.Update(ruleta);
            Random rnd = new Random();
            int WinNumber = rnd.Next(0, 37);
            string ColorWin = "";
            if (WinNumber % 2 == 0)
            {
                ColorWin = "rojo";
            }
            else
            {
                ColorWin = "negro";
            }
            IEnumerable<Apuesta> query = context.Apuesta.Where(p => p.IdRuleta == ruleta.Id & p.Color == ColorWin);
            foreach (Apuesta apuesta in query)
            {
                apuesta.state = "ganador";
                apuesta.WinMoney = (float)(apuesta.Money * 1.8);
                context.Apuesta.Update(apuesta);
            }
            IEnumerable<Apuesta> query2= context.Apuesta.Where(p => p.IdRuleta == ruleta.Id & (p.number==WinNumber));
            foreach (Apuesta apuesta in query2)
            {
                apuesta.state = "ganador";
                apuesta.WinMoney = apuesta.Money * 5;
                context.Apuesta.Update(apuesta);
            }

            context.SaveChanges();
            return context.Apuesta.Where(p => p.IdRuleta == ruleta.Id);
        }

    }
}
