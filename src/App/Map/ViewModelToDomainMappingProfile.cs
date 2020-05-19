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
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VooInserirViewModel, Voo>()
                 .ForMember(dest => dest.Id, map => map.MapFrom(src => Guid.NewGuid()))
                 .ForMember(dest => dest.Aeronave, map => map.MapFrom(src =>  new Aeronave { Id = new Guid(src.AeronaveId) } ))
                 .ForMember(dest => dest.AeroportoDestino, map => map.MapFrom(src => new Aeroporto { Id = new Guid(src.AeroportoDestinoId) }))
                 .ForMember(dest => dest.AeroportoOrigem, map => map.MapFrom(src => new Aeroporto { Id = new Guid(src.AeroportoOrigemId) }))
                 .ForMember(dest => dest.DataAgendamentoVoo, map => map.MapFrom(src => src.DataAgendamento))
                 .ForMember(dest => dest.TempoVooPrevisto, map => map.MapFrom(src => src.DataAgendamento))
                ;
            CreateMap<VooAlterarViewModel, Voo>()
                 .ForMember(dest => dest.Id, map => map.MapFrom(src => new Guid(src.Id.ToString())))
                 .ForMember(dest => dest.Aeronave, map => map.MapFrom(src => new Aeronave { Id = new Guid(src.AeronaveId) }))
                 .ForMember(dest => dest.AeroportoDestino, map => map.MapFrom(src => new Aeroporto { Id = new Guid(src.AeroportoDestinoId) }))
                 .ForMember(dest => dest.AeroportoOrigem, map => map.MapFrom(src => new Aeroporto { Id = new Guid(src.AeroportoOrigemId) }))
                 .ForMember(dest => dest.DataAgendamentoVoo, map => map.MapFrom(src => src.DataAgendamento))
                 .ForMember(dest => dest.TempoVooPrevisto, map => map.MapFrom(src => src.DataAgendamento))
                ;

        }
    }
}
