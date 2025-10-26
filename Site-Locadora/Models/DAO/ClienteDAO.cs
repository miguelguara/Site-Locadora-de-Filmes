using Dapper;

namespace Site_Locadora.Models.DAO
{
    public class ClienteDAO : Conexao
    {
        public List<Cliente> Listar()
        {
            return banco.Query<Cliente>("SELECT * FROM Clientes ORDER BY Nome").ToList();
        }

        public Cliente Buscar(int id)
        {
            return banco.Query<Cliente>("SELECT * FROM Clientes WHERE Id = @id", new { id }).SingleOrDefault();
        }

        public int Inserir(Cliente cliente)
        {
            var sql = @"INSERT INTO Clientes (Nome, Cpf, Telefone)
                        VALUES (@Nome, @Cpf, @Telefone)
                        RETURNING Id;";
            return banco.Query<int>(sql, cliente).Single();
        }

        public bool Atualizar(Cliente cliente)
        {
            var sql = @"UPDATE Clientes SET
                        Nome = @Nome,
                        Cpf = @Cpf,
                        Telefone = @Telefone
                        WHERE Id = @Id";
            return banco.Execute(sql, cliente) > 0;
        }

        public void Excluir(int id)
        {
            var sql = "DELETE FROM Clientes WHERE Id = @Id";
            banco.Execute(sql, new { Id = id });
        }
    }
}
