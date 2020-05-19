using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Aeronave:EntidadeBase
    {

        public string Matricula { get; set; }

        public IEnumerable<Voo> Voos { get; set; }

        public Aeronave()
        {
            Voos = new List<Voo>();
        }

    }
}
