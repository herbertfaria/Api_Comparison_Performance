using System.Text.Json;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.EntityFrameworkCore;
using Net.Webapi.Database;
using Net.Webapi.Database.Entities;
using Net.Webapi.Endpoints.ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<NetContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var faker = new Faker<Pessoa>("pt_BR").StrictMode(true)
.RuleFor(p => p.CPF, f => f.Person.Cpf().Replace("-", "").Replace(".",""))
.RuleFor(p => p.Nome, f => f.Person.FullName)
.RuleFor(p => p.Idade, f => f.Random.Int(0, 80));

// var pessoas = Enumerable.Range(0, 100_000)
// .Select(_ => new 
// {
//     Cpf = faker.Person.Cpf(),
//     Nome = faker.Person.FullName,
//     Idade = faker.Random.Int(0, 80)
// });

File.AppendAllText("../testes-carga/data.json", JsonSerializer.Serialize(faker.Generate(100_000)));

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
