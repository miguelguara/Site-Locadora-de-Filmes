using Dapper;

namespace Site_Locadora.Models.DAO
{
    public class AluguelDAO:Conexao
    {
        public List<Aluguel> Listar()
        {
            var sql = @"SELECT * FROM Alugueis ORDER BY DataAluguel DESC";
            return banco.Query<Aluguel>(sql).ToList();
        }

        public Aluguel Buscar(int id)
        {
            var sql = "SELECT * FROM Alugueis WHERE Id = @id";
            return banco.Query<Aluguel>(sql, new { id }).SingleOrDefault();
        }

        public int Inserir(Aluguel aluguel)
        {
            var sql = @"INSERT INTO Alugueis (IdCliente, IdFilme, DataAluguel, DataDevolucao)
                        VALUES (@IdCliente, @IdFilme, @DataAluguel, @DataDevolucao)
                        RETURNING Id;";
            return banco.Query<int>(sql, aluguel).Single();
        }

        public bool Atualizar(Aluguel aluguel)
        {
            var sql = @"UPDATE Alugueis SET
                        IdCliente = @IdCliente,
                        IdFilme = @IdFilme,
                        DataAluguel = @DataAluguel,
                        DataDevolucao = @DataDevolucao
                        WHERE Id = @Id";
            return banco.Execute(sql, aluguel) > 0;
        }

        public void Excluir(int id)
        {
            var sql = "DELETE FROM Alugueis WHERE Id = @Id";
            banco.Execute(sql, new { Id = id });
        }
    }
}

