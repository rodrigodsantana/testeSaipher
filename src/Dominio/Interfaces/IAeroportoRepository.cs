using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Dominio.Interfaces
{
  public  interface IAeroportoRepository : IRepository<Aeroporto>
    {

        Task<IEnumerable<AeroportoViewModel>> ObterAeroportos();
    }
}
