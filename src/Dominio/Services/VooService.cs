using AutoMapper;
using CrossCutting;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidarVm;
using ViewModel;

namespace Dominio.Services
{
    public class VooService : ServicoBase<Voo>, IVooService
    {

        readonly IAeronaveRepository _aeronaveRepository;
        readonly IAeroportoRepository _aeroportoRepository;
        readonly AutoMapper.IMapper _mapper;

        public VooService(AutoMapper.IMapper mapper,
                                     IAeroportoRepository aeroportoRepository,
                                     IAeronaveRepository aeronaveRepository,
                                     IVooRepository repositorio, 
                                     LNoty notificacoes) : base(repositorio, notificacoes)
        {

            _aeroportoRepository = aeroportoRepository;
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;

        }

        public async Task<VooAlterarViewModel> AlterarVoo(VooAlterarViewModel vooInserirViewModel)
        {
            /*fast validation validações de campo má pratica utilizar nas propriedades da view model*/
            var vl = new ValidarVooAlterarViewModel(vooInserirViewModel);
            if (!vl.Evalido)
                _notificacoes.AddRange(vl.notys);

            if (_notificacoes.TemErros)
                return vooInserirViewModel;

            await ValidacaoCampos(vooInserirViewModel);

            if (_notificacoes.TemErros)
                return vooInserirViewModel;

            var vooA = _mapper.Map<Voo>(vooInserirViewModel);
            var vooAdd = await _repositorio.Atualizar(vooA);
            vooInserirViewModel.Id = vooAdd.Id.ToString();

            return vooInserirViewModel;
        }

        public async Task<VooExcluirViewModel> ExcluirVoo(Guid guid)
        {
            VooExcluirViewModel _vooExcluirViewModel = new VooExcluirViewModel();
            _vooExcluirViewModel.Id = guid.ToString();
            var vl = new ValidarVooExcluirViewModel(_vooExcluirViewModel);
            if (!vl.Evalido)
                _notificacoes.AddRange(vl.notys);

            if (_notificacoes.TemErros)
                return _vooExcluirViewModel;

            await _repositorio.Remover(new Guid(_vooExcluirViewModel.Id));

           return _vooExcluirViewModel;
        }

        public async Task<VooInserirViewModel> InserirVoo(VooInserirViewModel vooInserirViewModel)
        {
            /*fast validation validações de campo má pratica utilizar nas propriedades da view model*/
            var vl = new ValidarVooInserirViewModel(vooInserirViewModel);
            if (!vl.Evalido)
                _notificacoes.AddRange(vl.notys);

            if (_notificacoes.TemErros)
                return vooInserirViewModel;

            await ValidacaoCampos(vooInserirViewModel);

            if (_notificacoes.TemErros)
                return vooInserirViewModel;


            var vooA = _mapper.Map<Voo>(vooInserirViewModel);
            var vooAdd = await _repositorio.Adicionar(vooA);

            vooInserirViewModel.Id = vooAdd.Id.ToString();

            return vooInserirViewModel;


        }

        async Task ValidacaoCampos(VoorViewModel vooInserirViewModel)
        {
            var aeroportoOrigem = await _aeroportoRepository.ObterPorId(new Guid(vooInserirViewModel.AeroportoOrigemId));
            var aeroportoDestino = await _aeroportoRepository.ObterPorId(new Guid(vooInserirViewModel.AeroportoDestinoId));
            var aeroNave = await _aeronaveRepository.ObterPorId(new Guid(vooInserirViewModel.AeronaveId));



            if (aeroportoOrigem == null)
            {
                _notificacoes.Add(new Noty { Mensagem = " Atenção! aeroportoOrigem não encontrado. " });

            }

            if (aeroportoOrigem!= null && !aeroportoOrigem.Ativo)
            {
                _notificacoes.Add(new Noty { Mensagem = " Atenção! aeroportoOrigem não está ativo. " });

            }

            if (aeroNave == null)
            {
                _notificacoes.Add(new Noty { Mensagem = " Atenção! aeroNave não encontrada. " });

            }

            if (aeroNave!= null && !aeroNave.Ativo)
            {
                _notificacoes.Add(new Noty { Mensagem = " Atenção! aeroNave não está ativo. " });

            }


            if (aeroportoDestino == null)
            {
                _notificacoes.Add(new Noty { Mensagem = " Atenção! aeroportoDestino não encontrado. " });

            }

            if (aeroportoDestino != null && !aeroportoDestino.Ativo)
            {
                _notificacoes.Add(new Noty { Mensagem = " Atenção! aeroportoDestino não está ativo. " });

            }
        }
    }
}
