
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiDrinkInTheHouse.Model
{
    public class Bebida 
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDbebida { get; set ; }
        public int STOCK {  get; set ; }    
        public string BRAND { get; set;  }
        public int PORCENTAJE_ALC { get; set; }
        public bool RETORNABLE { get; set; }
        public decimal PRECIO { get; set; }
        public int VENVIDO { get; set; }   
    }
}
