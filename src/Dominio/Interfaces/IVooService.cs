using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Dominio.Interfaces
{
   public interface IVooService:IServiceBase<Voo>
    {

        Task<VooInserirViewModel> InserirVoo(VooInserirViewModel vooInserirViewModel);

        Task<VooAlterarViewModel> AlterarVoo(VooAlterarViewModel vooInserirViewModel);


        Task<VooExcluirViewModel> ExcluirVoo(Guid guid);

        

    }
}
