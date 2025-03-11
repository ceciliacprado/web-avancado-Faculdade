using Microsoft.AspNetCore.Mvc;
using MeuProjetoMinimalAPI.Models; //para usar a classe Produto (de models)

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>(); //deixa o banco disponivel em qualquer lugar da aplicação para ser utilizado
var app = builder.Build();

//definir os endpoints (simples e complexos)
app.MapGet("/", () => "Revisão de web api e entity framework");

app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto, 
[FromServices] AppDataContext banco) => { //dados são enviados no corpo da requisição, e os dados do banco são envados
    banco.Produtos.Add(produto);
    banco.SaveChanges();
    return Results.Created("", produto); //retorna o produto cadastrado
});

app.MapGet("/api/produto/listar", ([FromServices] AppDataContext banco) => { //dados do banco são pegados
   return Results.Ok(banco.Produtos.ToList()); //retorna a lista de produtos
});

app.Run();
