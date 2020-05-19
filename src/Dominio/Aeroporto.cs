using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Aeroporto : EntidadeBase
    {

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public IEnumerable<Voo> Voos { get; set; }

        public Aeroporto()
        {
            Voos = new List<Voo>();
        }

    }
}
