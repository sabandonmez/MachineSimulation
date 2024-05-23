using MachineSimulation.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Abstract
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> GetAllUsers();

        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task<UserDtoForUpdate> GetUserForUpdate(string userName);

        Task<IdentityUser> GetOneUser(string userName);

        Task Update(UserDtoForUpdate userDto);

        Task<IdentityResult> ResetPassword(ResetPasswordDto model);
        Task<IdentityResult> DeleteOneUser(string userName);
    }
}
