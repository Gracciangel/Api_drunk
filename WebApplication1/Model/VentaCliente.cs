using ApiDrinkInTheHouse.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class VentaCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ITEM { get; set; }    
        public int CANTIDAD { get; set; }   
        public string CLIENTE {  get; set; }    
        public decimal TOTAL_CLIENTE { get; set; }

        [ForeignKey("IdUsuario")]
        public int UsuarioID { get; set; }  
        public virtual Usuario Usuario { get; set; }    
       
        [ForeignKey("IDbebida")]
        public int BebidaID { get; set; }   
        public virtual Bebida Bebida { get; set; }

    }
}
