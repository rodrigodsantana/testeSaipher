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
    public class AeronaveApp : AppBase, IAeronaveApp
    {

        readonly IAeronaveRepository _aeronaveRepository;
        readonly AutoMapper.IMapper _mapper;


        public AeronaveApp(AutoMapper.IMapper mapper,IAeronaveRepository aeronaveRepository,LNoty notificacoes) : base(notificacoes)
        {
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AeronaveViewModel>> ObterAeronaves()
        {
            return await _aeronaveRepository.ObterAeronaves();
        }
    }
}
