public class Produto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
<<<<<<< HEAD
    public string? Nome { get; set; } 

    //podemos tambem por o interrogação no STRING para que não incorra erro
    // ou string empty para que não seja nulo, mas sim vazio
=======
    public string Nome { get; set; } = String.Empty;
>>>>>>> 80bfa2a8c3e15057f03b81843abb55c5f285813e
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}