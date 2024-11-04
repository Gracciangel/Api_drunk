using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDrinkInTheHouse.Model
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; } 
        public string NOMBRE {  get; set; }    
        public string APELLIDO { get; set; }
        public string EMAIL { get; set; }   
        public string PASSWORD { get; set; }
        public DateTime FECHA_NAC { get; set; }
        public string DNI {  get; set; }    

    }
}
