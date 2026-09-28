public class Produto
{

    //Construtor
    // public Produto()
    // {
    //     CriadoEm = DateTime.Now;
    // }

    //C#
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Nome { get; set; } 

    //podemos tambem por o interrogação no STRING para que não incorra erro
    // ou string empty para que não seja nulo, mas sim vazio
    public DateTime CriadoEm { get; set; } = DateTime.Now;

    //JAVA
    // private string nome;
    // public void setNome(string nome)
    // {
    //     this.nome = nome;
    // }
    // public string getNome()
    // {
    //     return nome;
    // }
}