namespace Site_Locadora.Models
{
    public class Aluguel
    {
        public int Id { get; set; }           
        public int IdCliente { get; set; }  
        public int IdFilme { get; set; }      
        public DateTime DataAluguel { get; set; }
        public DateTime? DataDevolucao { get; set; } 
    }
}
