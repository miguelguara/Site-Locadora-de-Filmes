namespace Site_Locadora.Models
{
    public class Cliente
    {
        public int Id { get; set; }          // SERIAL no PostgreSQL
        public string Nome { get; set; }     // VARCHAR
        public string Cpf { get; set; }      // VARCHAR(14)
        public string Telefone { get; set; } // VARCHAR
    }
}
