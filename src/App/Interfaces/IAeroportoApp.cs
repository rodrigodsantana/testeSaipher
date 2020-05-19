using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace App.Interfaces
{
   public interface IAeroportoApp : IAppBase
    {
        Task<IEnumerable<AeroportoViewModel>> ObterAeroportos();
    }
}
