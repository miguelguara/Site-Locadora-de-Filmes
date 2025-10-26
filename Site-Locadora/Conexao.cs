using Npgsql;

namespace Site_Locadora
{
    public class Conexao
    {
        public NpgsqlConnection banco;
        public Conexao()
        {

            //Talvez seja necessário mudar alguns parametros para o site funcionar na sua máquina ;)
            banco = new NpgsqlConnection("Host=localhost;Port=5432;Database=sitefilme;Username=postgres;Password=1234;");
        }
    }
}
