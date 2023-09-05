using AutoMapper;
using Dominio.Entities;
using Api.Dtos;


namespace Api.Profiles;
    public class MappingProfiles : Profile{

        public MappingProfiles(){
            CreateMap<Alumno, AlumnoDto>()
                .ReverseMap();

            /* .ForMember(p => p.Profesores) */
        }
    }
