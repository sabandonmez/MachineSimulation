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
		}
	}
}
