//POSTMAN
//INSONMIA
//REST CLIENT - Extensão do VSCODE

//TERMINAL
//1 - Criar solução
//2 - Entrar na pasta da solução
//3 - Criar o projeto
//4 - Vincular o projeto para a solução
// Console.Clear();

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>();

//FUNCIONALIDADES - EndPoints
//Requisições
// - Método HTTP
// - URL
// - Opcional - Corpo/Parâmetros de URL

//Resposta
// - Dado/Informação/Mensagem
// - Código de Status HTTP

//GET: http://localhost:5195/
app.MapGet("/", () => "API do Ecommerce");

//GET: /api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    if (produtos.Count == 0)
    {
        return Results.BadRequest("A lista de produtos está vazia");
    }
    return Results.Ok(produtos);
});

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", (Produto? produto) =>
{

    if (produto is null)
    {
        return Results.BadRequest("O produto não pode ser nulo");
    }

    if (produto.Nome == "")
    {
        return Results.BadRequest("O nome não pode ser vazio");
    }

    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == produto.Nome)
        {
            return Results.BadRequest("Já existe um produto com o mesmo nome");
        }
    }
    produtos.Add(produto);
    return Results.Created("", produto);
});

//GET: /api/produto/buscar/nome_produto
app.MapGet("/api/produto/buscar/{nome}", (string nome) =>
{
    //Expressão lambda
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Nome == nome);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    return Results.Ok(produtoEncontrado);    
});

//DELETE: /api/produto/remover/id_produto
app.MapDelete("/api/produto/remover/{id}", (string id) =>
{
    //Expressão lambda
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Id == id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    produtos.Remove(produtoEncontrado);
    return Results.Ok(produtoEncontrado);    
});

//DELETE: /api/produto/alterar/id_produto
app.MapPut("/api/produto/alterar/{id}", 
    ([FromRoute] string id, 
    [FromBody] Produto produtoAlterado) =>
{
    //Expressão lambda
    Produto? produtoEncontrado = produtos.FirstOrDefault(x => x.Id == id);
    if (produtoEncontrado is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    
    produtoEncontrado.Nome = produtoAlterado.Nome;
    return Results.Ok(produtoEncontrado);    
});


app.Run();

//EXERCÍCIO
// 2 - Remoção de um produto
// 3 - Alteração de produto


