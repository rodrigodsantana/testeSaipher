using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{


   public class Voo : EntidadeBase
    {

        public Aeronave Aeronave { get; set; }

        public Aeroporto AeroportoDestino { get; set; }

        public Aeroporto AeroportoOrigem { get; set; }

        public DateTime   TempoVooPrevisto { get; set; }

        public DateTime?  TempoVooEfetivado { get; set; }

        public DateTime   DataAgendamentoVoo { get; set; }

        

    }
}
