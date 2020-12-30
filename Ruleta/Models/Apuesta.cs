using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruleta.Models
{
    public class Apuesta
    {
        public int Id { get; set; }
        public int number { get; set; }
        public string Color { get; set; }
        public int Money { get; set; }
        public int IdRuleta { get; set; }
        public string state { get; set; }
        public float WinMoney { get; set; }
    }
}
