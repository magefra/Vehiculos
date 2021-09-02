using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vehiculos.API.Data;
using Vehiculos.API.Data.Entities;
using Vehiculos.API.Models;

namespace Vehiculos.API.Helpers
{
    public class UsuarioHelper : IUsuarioHelper
    {

        private readonly UserManager<Usuario> _usuarioManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _dataContext;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioHelper(UserManager<Usuario> usuarioManager, RoleManager<IdentityRole> roleManager, DataContext dataContext, SignInManager<Usuario> signInManager)
        {

            _usuarioManager = usuarioManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
            _signInManager = signInManager;
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

        public async Task<Usuario> GetUserAsync(Guid id)
        {
            return await _dataContext.Usuarios
                .Include(x => x.TipoDocumento)
                .FirstOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task<bool> IsUserInRoleAsync(Usuario user, string roleName)
        {
            return await _usuarioManager.IsInRoleAsync(user, roleName);
        }


        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Usuario, model.Password,model.Recuerdame, false);
        }


        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }



        public async Task<IdentityResult> UpdateUserAsync(Usuario user)
        {
            Usuario currentUser = await GetUserAsync(user.Email);
            currentUser.Nombre = user.Nombre;
            currentUser.Apellidos = user.Apellidos;
            currentUser.TipoDocumento = user.TipoDocumento;
            currentUser.Documento = user.Documento;
            currentUser.Direccion = user.Direccion;
            currentUser.IdImagen = user.IdImagen;
            currentUser.PhoneNumber = user.PhoneNumber;
            return await _usuarioManager.UpdateAsync(currentUser);
        }
    }
}
