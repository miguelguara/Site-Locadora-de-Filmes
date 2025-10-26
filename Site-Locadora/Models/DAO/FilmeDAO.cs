using Dapper;

namespace Site_Locadora.Models.DAO
{
    public class FilmeDAO: Conexao
    {
        public List<Filme> Listar()
        {
            return banco.Query<Filme>("SELECT * FROM Filmes ORDER BY Titulo").ToList();
        }

        public Filme Buscar(int id)
        {
            return banco.Query<Filme>("SELECT * FROM Filmes WHERE Id = @id", new { id }).SingleOrDefault();
        }

        public int Inserir(Filme filme)
        {
            var sql = @"INSERT INTO Filmes (Titulo, Ano, Diretor, Genero, Poster, ImdbID)
                        VALUES (@Titulo, @Ano, @Diretor, @Genero, @Poster, @ImdbID)
                        RETURNING Id;";
            return banco.Query<int>(sql, filme).Single();
        }

        public bool Atualizar(Filme filme)
        {
            var sql = @"UPDATE Filmes SET
                        Titulo = @Titulo,
                        Ano = @Ano,
                        Diretor = @Diretor,
                        Genero = @Genero,
                        Poster = @Poster,
                        ImdbID = @ImdbID
                        WHERE Id = @Id";
            return banco.Execute(sql, filme) > 0;
        }

        public void Excluir(int id)
        {
            var sql = "DELETE FROM Filmes WHERE Id = @Id";
            banco.Execute(sql, new { Id = id });
        }
    }
}
