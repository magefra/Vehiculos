using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vehiculos.API.Data;
using Vehiculos.API.Data.Entities;

namespace Vehiculos.API.Helpers
{
    public class UsuarioHelper : IUsuarioHelper
    {

        private readonly UserManager<Usuario> _usuarioManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _dataContext;

        public UsuarioHelper(UserManager<Usuario> usuarioManager, RoleManager<IdentityRole> roleManager, DataContext dataContext)
        {

            _usuarioManager = usuarioManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
        }


        public async Task<IdentityResult> AddUserAsync(Usuario user, string password)
        {
            return await _usuarioManager.CreateAsync(user, password);
        }
    

        public async Task AddUserToRoleAsync(Usuario user, string roleName)
        {
            await _usuarioManager.AddToRoleAsync(user, roleName);

        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        public async Task<Usuario> GetUserAsync(string email)
        {
            return await _dataContext.Usuarios
                .Include(x => x.TipoDocumento)         
                .FirstOrDefaultAsync(x => x.Email == email);
        }



        public async Task<bool> IsUserInRoleAsync(Usuario user, string roleName)
        {
            return await _usuarioManager.IsInRoleAsync(user, roleName);
        }
    }
}
