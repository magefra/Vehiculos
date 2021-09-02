using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data.Entities;
using Vehiculos.API.Models;

namespace Vehiculos.API.Helpers
{
    public interface IUsuarioHelper
    {
        Task<Usuario> GetUserAsync(string email);

        Task<Usuario> GetUserAsync(Guid id);

        Task<IdentityResult> AddUserAsync(Usuario user, string password);

        Task<IdentityResult> UpdateUserAsync(Usuario user);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Usuario user, string roleName);

        Task<bool> IsUserInRoleAsync(Usuario user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
    }
}
