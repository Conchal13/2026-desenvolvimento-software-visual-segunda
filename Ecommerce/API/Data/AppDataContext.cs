using Microsoft.EntityFrameworkCore;
//configuração do banco de dados
//1- instalar bibliotecas
//2- criar a classe de dados (AppDataContext)
//3- criar a hernaça da classe de dados(BIBLIO) (DbContext)
//4 - indicar as classes de modelo que tornars-se-ão tabelas no banco de dados (DbSet<Produto> Produtos_table) 
//5 - configurar a string de conexão com o banco de dados (UseSqlite("Data Source=Ecommerce.db"))

public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos_table { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }
}