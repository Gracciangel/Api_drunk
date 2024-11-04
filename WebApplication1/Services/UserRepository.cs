using ApiDrinkInTheHouse.DTO_S;
using ApiDrinkInTheHouse.Interfaces;
using ApiDrinkInTheHouse.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApplication1.DTO_S;
using WebApplication1.Interfaces;
using WebApplication1.Model;
namespace WebApplication1.Services
{
    public class UserRepository : IUsers
    {
        private ContextoDB _contexto; 
        public UserRepository(ContextoDB contexto)
        {
            _contexto = contexto;    
        }

        //listar usuarios 
        public async Task<IEnumerable<UsuarioDTO>> GetAllusers()
        {
            return await  _contexto.Usuarios.Select(u => new UsuarioDTO
            {
                NOMBRE = u.NOMBRE,
                APELLIDO = u.APELLIDO,
                EMAIL = u.EMAIL,
                PASSWORD = u.PASSWORD,
                FECHA_NAC = u.FECHA_NAC,
                DNI = u.DNI,
            }).ToListAsync(); 
           
        }

        //agregagar un usuario 
   

       public async Task<string> AddUser(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario()
            {
                NOMBRE = usuarioDTO.NOMBRE,
                APELLIDO = usuarioDTO.APELLIDO,
                EMAIL = usuarioDTO.EMAIL,
                PASSWORD = usuarioDTO.PASSWORD,
                DNI = usuarioDTO.DNI,
            }; 
            await _contexto.Usuarios.AddAsync(usuario);
            var save = await _contexto.SaveChangesAsync();

            if (save != null)
            {
                return $"usuario {usuario.NOMBRE} agregado correctamente";
            }
            else
            {
                return "fallo en la carga de usuario" ;
            }
        
        }
    }
}
