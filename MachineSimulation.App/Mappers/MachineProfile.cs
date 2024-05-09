using AutoMapper;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;

namespace MachineSimulation.API.Mappers
{
	public class MachineProfile : Profile
	{
		public MachineProfile()
		{
			CreateMap<MachineDto, Machine>();
			CreateMap<Machine, MachineDto>();

			CreateMap<MachineDetailsDto,Machine>();
			CreateMap<Machine,MachineDetailsDto>();

			CreateMap<Stoppage,StoppageDto>();
			CreateMap<StoppageDto,Stoppage>();


		}
	}
}
