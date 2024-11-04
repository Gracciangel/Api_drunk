using ApiDrinkInTheHouse.DTO_S;
using ApiDrinkInTheHouse.Interfaces;
using ApiDrinkInTheHouse.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebApplication1.DTO_S;
using WebApplication1.Interfaces;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUsers _users; 
        public UserController(IUsers users)
        {
           _users = users;  
        }

        //verbs 

        [HttpGet("all")]
        public async Task<IEnumerable<UsuarioDTO>> GetAllUsers()
        {
            var response = await _users.GetAllusers();
            if(response == null)
            {
                return Enumerable.Empty<UsuarioDTO>();
            }
            else
            {
                return response;     
            }
        }

        //post
        [HttpPost("add")]
        public async Task<string> AddUser(UsuarioDTO usuario ) => await  _users.AddUser(usuario); 
    }
}




