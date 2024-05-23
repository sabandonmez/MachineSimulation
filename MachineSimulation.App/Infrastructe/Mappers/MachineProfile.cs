using AutoMapper;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using Microsoft.AspNetCore.Identity;

namespace MachineSimulation.App.Infrastructe.Mappers
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            CreateMap<MachineDto, Machine>();
            CreateMap<Machine, MachineDto>();

            CreateMap<MachineDetailsDto, Machine>();
            CreateMap<Machine, MachineDetailsDto>();

            CreateMap<Stoppage, StoppageDto>();
            CreateMap<StoppageDto, Stoppage>();

            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();

        }
    }
}
