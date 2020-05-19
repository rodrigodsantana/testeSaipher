using App.Interfaces;
using CrossCutting;
using Dominio;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace App.Services
{
    public class AeroportoApp : AppBase, IAeroportoApp
    {

        readonly IAeroportoRepository _aeroportoRepository;

        public AeroportoApp(IAeroportoRepository aeroportoRepository, LNoty notificacoes) : base(notificacoes)
        {
            _aeroportoRepository = aeroportoRepository;
        }

        public async Task<IEnumerable<AeroportoViewModel>> ObterAeroportos()
        {
            return await _aeroportoRepository.ObterAeroportos();

        }
    }
}
