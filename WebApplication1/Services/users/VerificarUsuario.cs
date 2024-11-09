using ApiDrinkInTheHouse.DTO_S;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Services.users
{
    public class VerificarUsuario
    {
        private readonly ContextoDB _context;

        public VerificarUsuario(ContextoDB contexto)
        {
            _context = contexto;    
        }
        public async Task<int> Verify(UsuarioDTO usuario)
        {
            var emailExiste = await _context.Usuarios.AnyAsync(
                u => u.EMAIL == usuario.EMAIL); 
            var dniExiste = await _context.Usuarios.AnyAsync(
                u=> u.DNI == usuario.DNI);
            if (emailExiste)
            {
                return 1;
            }
            if (dniExiste)
            {
                return 2;
            }
            return 200;   
        }

        
    }
}
