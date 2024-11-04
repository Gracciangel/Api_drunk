namespace WebApplication1.DTO_S
{
    public class InsertBebidaDto
    {
        public string BRAND { get; set; }
        public int PORCENTAJE_ALC { get; set; }
        public bool RETORNABLE { get; set; }
        public decimal PRECIO { get; set; }
        public int VENVIDO { get; set; } = 0; 
    }
}
