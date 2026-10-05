using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
//configuração do banco de dados
//1- instalar bibliotecas
//2- criar a classe de dados (AppDataContext)
//3- criar a hernaça da classe de dados(BIBLIO) (DbContext)
//4 - indicar as classes de modelo que tornars-se-ão tabelas no banco de dados (DbSet<Produto> Produtos_table) 
//5 - configurar a string de conexão com o banco de dados (UseSqlite("Data Source=Ecommerce.db"))

public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos_table { get; set; }
=======

//CONFIGURAÇÃO COM BANCO DE DADOS
//1 - Instalar as bibliotecas
//2 - Criar a classe de dados
//3 - Criar a herança com a biblioteca
//4 - Indicar as classes de modelo que vão 
//virar tabelas no banco de dados
//5 - Sobrescrever o método de configuração, com banco
//utilizado e a string de conexão
public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
>>>>>>> 855d846b1d7dfa82a3f1ec108090496ce2cdf60c

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }
<<<<<<< HEAD
=======

>>>>>>> 855d846b1d7dfa82a3f1ec108090496ce2cdf60c
}