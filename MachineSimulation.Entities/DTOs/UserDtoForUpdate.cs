using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.DTOs
{
    public record UserDtoForUpdate : UserDto
    {
        public HashSet<String> UserRoles { get; set; } = new HashSet<string>();

    }
}
