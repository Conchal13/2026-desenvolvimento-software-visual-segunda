//POSTMAN
//INSONMIA
//REST CLIENT - Extensão do VSCODE

//TERMINAL
//1 - Criar solução
//2 - Entrar na pasta da solução
//3 - Criar o projeto
//4 - Vincular o projeto para a solução


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>();
/*{ 
    new Produto
    {
        Nome = "Notebook Pro 15"
    },
    new Produto
    {
        Nome = "Mouse Wireless"
    },
    new Produto
    {
        Nome = "Teclado Mecânico RGB"
    },
    new Produto
    {
        Nome = "Monitor 27 Full HD"
    },
    new Produto
    {
        Nome = "Headset Gamer"
    },
    new Produto
    {
        Nome = "Webcam Full HD"
    },
    new Produto
    {
        Nome = "SSD 1TB NVMe"
    },
    new Produto
    {
        Nome = "Cadeira Gamer"
    },
    new Produto
    {
        Nome = "Smartphone Max 256GB"
    },
    new Produto
    {
        Nome = "Tablet 10 Polegadas"
    }
};   */

//FUNCIONALIDADES - EndPoint
//sempre será acessado por :
//Requisições
// - Método HTTP
// - URL
// RETORNARÁ RESPOSTA 
// - Dado/Informação/MENSAGEM
// PRECISA DE CODIGO DE STATUS HTTP


// GET: http://localhost:5195
app.MapGet("/", () => "API do Ecommerce");

// /API/PRODUTO/LISTAR
app.MapGet("/api/produto/listar", () =>
{
    if (produtos.Count == 0)
    {
        return Results.NotFound("Não existem produtos cadastrados");
    }
    return Results.Ok(produtos);
});

//Metodo POST para URL 
//POST: /API/produto/cadastrar
app.MapPost("/api/produto/cadastrar", (Produto? produto) =>
{
    if(produto is null)
    {
        return Results.BadRequest("Produto inválido");
    }  
    

    //validar se ja existe algo preenchido no nome do produto
    //validar se ja existe um produto cadastrado com o mesmo nome
    if(produto.Nome == ""){
        return Results.BadRequest("Produto inválido ou já cadastrado");
    }   

    foreach(Produto produtoCadastrado in produtos)
    {
        if(produtoCadastrado.Nome == produto.Nome)
        {
            return Results.BadRequest("Produto com mesmo nome já cadastrado");
        }
    }   
    
    produtos.Add(produto);
    return Results.Created("", produto);


});
//GET: /api/produto/buscar/nome
app.MapGet("/api/produto/buscar/{nome}", (string nome) =>
{
    List<Produto> produtosEncontrados = produtos.FindAll(p => p.Nome != null && p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));

    if (produtosEncontrados.Count == 0)
    {
        return Results.NotFound("Nenhum produto encontrado com o nome informado");
    }

    return Results.Ok(produtosEncontrados);
});

app.Run();

//EXERCÍCIO
// 2 - Remoção de um produto
// 3 - Alteração de produto

// EXERCICIO
// 1 PESQUISA POR NOME
// 2 REMOÇÃO
// ALTERAÇÃO DE PRODUTO