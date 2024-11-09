using System.ComponentModel.DataAnnotations;

namespace ApiDrinkInTheHouse.DTO_S
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage ="Debes ingresar un nombre")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Debes ingresar tu apellido")]
        public string APELLIDO { get; set; }

        [Required(ErrorMessage = "Debes ingresar un email valido")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "Debes ingresar una constraseña")]
        public string PASSWORD { get; set; }
        [Required(ErrorMessage = "Debes ingresar una fecha de nacimiento")]
        public DateTime FECHA_NAC { get; set; }
        [Required(ErrorMessage = "Debes ingresar un numero de documento")]
        public string DNI { get; set; }
    }
}
