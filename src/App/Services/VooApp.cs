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
    public class VooApp : AppBase, IVooApp
    {

        readonly IVooService _vooService;
        readonly IVooRepository _vooRepository;
        readonly AutoMapper.IMapper _mapper;

        public VooApp(AutoMapper.IMapper mapper,IVooRepository vooRepository,IVooService vooService,LNoty notificacoes) : base(notificacoes)
        {
            _vooService = vooService;
            _mapper = mapper;
            _vooRepository = vooRepository;
        }

        public async Task<VooAlterarViewModel> AlterarVoo(VooAlterarViewModel vooInserirViewModel)
        {
            return await _vooService.AlterarVoo(vooInserirViewModel);
        }

        public async Task<VooExcluirViewModel> ExcluirVoo(Guid guid)
        {
            return await _vooService.ExcluirVoo(guid);
        }

        public async Task<VooInserirViewModel> InserirVoo(VooInserirViewModel vooInserirViewModel)
        {
            //var v = _mapper.Map<Voo>(vooInserirViewModel);
            return await _vooService.InserirVoo(vooInserirViewModel);
        }

        public async Task<VooListaViewModel> ObterVoo(Guid guid)
        {
            var voo = await _vooRepository.ObterPorId(guid);
            if (voo == null)
                return null;
            return _mapper.Map<VooListaViewModel>(voo);
            
        }

        public Task<IEnumerable<VooListaViewModel>> ObterVoos(VooConsultaViewModel vooConsultaViewModel)
        {
            return _vooRepository.ObterVoos(vooConsultaViewModel);
        }
    }
}
