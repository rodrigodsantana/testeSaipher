using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Dominio.Interfaces
{
   public interface IVooRepository: IRepository<Voo>
    {

        Task<IEnumerable<VooListaViewModel>> ObterVoos(VooConsultaViewModel vooConsultaViewModel);

    }
}
