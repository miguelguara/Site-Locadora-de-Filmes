CREATE TABLE Clientes (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(100),
    Cpf VARCHAR(14),
    Telefone VARCHAR(20)
);

CREATE TABLE Filmes (
    Id SERIAL PRIMARY KEY,
    Titulo VARCHAR(200),
    Ano VARCHAR(10),
    Diretor VARCHAR(100),
    Genero VARCHAR(100),
    Poster TEXT,
    ImdbID VARCHAR(20)
);

CREATE TABLE Alugueis (
    Id SERIAL PRIMARY KEY,
    IdCliente INT REFERENCES Clientes(Id),
    IdFilme INT REFERENCES Filmes(Id),
    DataAluguel TIMESTAMP NOT NULL,
    DataDevolucao TIMESTAMP
);