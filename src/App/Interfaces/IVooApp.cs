using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace App.Interfaces
{
   public interface IVooApp: IAppBase
    {
        Task<VooInserirViewModel> InserirVoo(VooInserirViewModel vooInserirViewModel);

        Task<VooAlterarViewModel> AlterarVoo(VooAlterarViewModel vooInserirViewModel);


        Task<VooExcluirViewModel> ExcluirVoo(Guid guid);

        Task<IEnumerable<VooListaViewModel>> ObterVoos(VooConsultaViewModel vooConsultaViewModel);

        Task<VooListaViewModel> ObterVoo(Guid guid);
    }
}
