using AutoMapper;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace App.Map
{
  public  class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {

            CreateMap<Voo, VooInserirViewModel>()
                 .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id.ToString()))
                 .ForMember(dest => dest.DataAgendamento, map => map.MapFrom(src => src.DataAgendamentoVoo))
                 .ForMember(dest => dest.AeroportoOrigemId, map => map.MapFrom(src => src.AeroportoOrigem == null ? Guid.Empty : src.AeroportoOrigem.Id))
                 .ForMember(dest => dest.AeroportoDestinoId, map => map.MapFrom(src => src.AeroportoDestino == null ? Guid.Empty : src.AeroportoDestino.Id))
                 .ForMember(dest => dest.AeronaveId, map => map.MapFrom(src => src.Aeronave == null ? Guid.Empty : src.Aeronave.Id))
                ;
            CreateMap<Voo, VooAlterarViewModel >()
                 .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id.ToString()))
                 .ForMember(dest => dest.DataAgendamento, map => map.MapFrom(src => src.DataAgendamentoVoo))
                 .ForMember(dest => dest.AeroportoOrigemId, map => map.MapFrom(src => src.AeroportoOrigem == null ? Guid.Empty : src.AeroportoOrigem.Id))
                 .ForMember(dest => dest.AeroportoDestinoId, map => map.MapFrom(src => src.AeroportoDestino == null ? Guid.Empty : src.AeroportoDestino.Id))
                 .ForMember(dest => dest.AeronaveId, map => map.MapFrom(src => src.Aeronave == null ? Guid.Empty : src.Aeronave.Id))
                ;

            CreateMap<Voo, VooListaViewModel>()
                  .ForMember(dest => dest.VooId, map => map.MapFrom(src => src.Id.ToString()))
                  .ForMember(dest => dest.DescricaoVoo, map => map.MapFrom(src => src.Aeronave == null ? string.Empty : src.Aeronave.Matricula))
                  .ForMember(dest => dest.Aeronave, map => map.MapFrom(src => src.Aeronave == null ? string.Empty : src.Aeronave.Matricula))
                  .ForMember(dest => dest.AeronaveId, map => map.MapFrom(src => src.Aeronave == null ? string.Empty : src.Aeronave.Id.ToString()))
                  .ForMember(dest => dest.AeroportoDestino, map => map.MapFrom(src => src.AeroportoDestino == null ? string.Empty : src.AeroportoDestino.Nome))
                  .ForMember(dest => dest.AeroportoDestinoId, map => map.MapFrom(src => src.AeroportoDestino == null ? string.Empty : src.AeroportoDestino.Id.ToString()))
                  .ForMember(dest => dest.AeroportoOrigem, map => map.MapFrom(src => src.AeroportoOrigem == null ? string.Empty : src.AeroportoOrigem.Nome))
                  .ForMember(dest => dest.AeroportoOrigemId, map => map.MapFrom(src => src.AeroportoOrigem == null ? string.Empty : src.AeroportoOrigem.Id.ToString()))
                  .ForMember(dest => dest.DataVoo, map => map.MapFrom(src => src.DataAgendamentoVoo.ToString()))
                  .ForMember(dest => dest.DataAgendamento, map => map.MapFrom(src => src.DataAgendamentoVoo))

                 ;

        }
    }
}
