using ApiIncidencePro.Dtos;
using AutoMapper;
using Dominio.Entities;


namespace Api.Profiles;
    public class MappingProfiles : Profile{

        public MappingProfiles(){
        CreateMap<Incidencia, IncidenciaDto>()
        .ReverseMap()
        .ForMember(o => o.DetalleDeIncidencias, d => d.Ignore()); // Previene el null
        CreateMap<DetalleIncidencia, DetalleIncidenciaDto>().ReverseMap();
        }

    }
