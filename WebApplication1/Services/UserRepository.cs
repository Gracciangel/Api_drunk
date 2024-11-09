using ApiDrinkInTheHouse.DTO_S;
using ApiDrinkInTheHouse.Interfaces;
using ApiDrinkInTheHouse.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.RegularExpressions;
using WebApplication1.DTO_S;
using WebApplication1.Interfaces;
using WebApplication1.Model;
using WebApplication1.Services.users;
namespace WebApplication1.Services
{
    public class UserRepository : IUsers
    {
        private bool _aceptado = false;
        private ContextoDB _contexto;
        VerificarUsuario _verificarUsuario; 
        public UserRepository(ContextoDB contexto, VerificarUsuario verificar)
        {
            _verificarUsuario = verificar;  
            _contexto = contexto;
        }

        //listar usuarios 
        public async Task<IEnumerable<UsuarioDTO>> GetAllusers()
        {
            return await _contexto.Usuarios.Select(u => new UsuarioDTO
            {
                NOMBRE = u.NOMBRE,
                APELLIDO = u.APELLIDO,
                EMAIL = u.EMAIL,
                PASSWORD = u.PASSWORD,
                FECHA_NAC = u.FECHA_NAC,
                DNI = u.DNI,
            }).ToListAsync();

        }


        //agregar usuario 

        public async Task<string> AddUser(UsuarioDTO usuarioDTO)
        {
            try
            {
                var existe = await _verificarUsuario.Verify(usuarioDTO); 

                if (existe == 1)
                {
                    return $"Hay un usuario registrado con el email {usuarioDTO.EMAIL}";
                }
                if(existe == 2)
                {
                    return $"Hay un usurio regitrado con el numero de dni {usuarioDTO.DNI}";
                }
                
                    var currentYear = DateTime.Now.Year;
                    var userAge = currentYear - usuarioDTO.FECHA_NAC.Year;
                    var patron = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
                    Regex regex = new Regex(patron);



                    if (DateTime.Now.DayOfYear < usuarioDTO.FECHA_NAC.DayOfYear)
                    {
                        userAge--;
                    }

                    if (userAge < 18)
                    {
                        return "El usuario debe ser mayor de 18 años";
                    }
                    if (!regex.IsMatch(usuarioDTO.EMAIL))
                    {
                        return $"el mail {usuarioDTO.EMAIL} ingresado es incorrecto";
                    }

                    var usuario = new Usuario
                    {
                        NOMBRE = usuarioDTO.NOMBRE,
                        APELLIDO = usuarioDTO.APELLIDO,
                        FECHA_NAC = usuarioDTO.FECHA_NAC,
                        EMAIL = usuarioDTO.EMAIL,
                        PASSWORD = usuarioDTO.PASSWORD,
                        DNI = usuarioDTO.DNI
                    };

                    await _contexto.Usuarios.AddAsync(usuario);
                    var saveResult = await _contexto.SaveChangesAsync();

                    if (saveResult > 0)
                    {
                        return $"Usuario {usuario} agregado correctamente";
                    }
                    else
                    {
                        return "Fallo en la carga del usuario";
                    }
                
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

           
        }
    }
    }
