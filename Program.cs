using Microsoft.AspNetCore.Mvc;
using MeuProjetoMinimalAPI.Models; //para usar a classe Produto (de models)

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>(); //deixa o banco disponivel em qualquer lugar da aplicação para ser utilizado

builder.Services.AddCors(options => { //configuração de cors - permitir requisições de outras origens (sem ser localhost:3000)
    options.AddPolicy("Acesso total", configs => configs.
    AllowAnyOrigin()  //permite requisições de qualquer origem
    .AllowAnyMethod() //permite requisições de qualquer método
    .AllowAnyHeader()); //permite requisições de qualquer cabeçalho
});

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

app.UseCors("Acesso total"); //usa a configuração de cors antes de rodar a aplicação
app.Run();
