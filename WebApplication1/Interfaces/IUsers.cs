using ApiDrinkInTheHouse.Model;
using Microsoft.AspNetCore.Mvc;
using ApiDrinkInTheHouse.DTO_S; 
namespace WebApplication1.Interfaces
{
    public interface IUsers
    {
        public Task<string> AddUser( UsuarioDTO usuarioDTO);

        public Task<IEnumerable<UsuarioDTO>> GetAllusers();

    }
}
