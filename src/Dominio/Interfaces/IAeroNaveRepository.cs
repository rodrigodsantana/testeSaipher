using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Dominio.Interfaces
{
   public interface IAeronaveRepository : IRepository<Aeronave>
    {
        Task<IEnumerable<AeronaveViewModel>> ObterAeronaves();
    }
}
