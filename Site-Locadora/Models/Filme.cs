namespace Site_Locadora.Models
{
    public class Filme
    {
        public int Id { get; set; }          // SERIAL no PostgreSQL
        public string Titulo { get; set; }
        public string Ano { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public string Poster { get; set; }  
        public string ImdbID { get; set; }  
    }
}
