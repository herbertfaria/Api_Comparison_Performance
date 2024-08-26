
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net.Webapi.Database;
using Net.Webapi.Database.Entities;
using Net.Webapi.Endpoints.ViewModel;

namespace Net.Webapi.Endpoints;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private readonly NetContext _context;

    public PessoaController(NetContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var pessoas = await _context.Pessoas
        .AsNoTracking()
        .ToArrayAsync();
        return Ok(pessoas);
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> Get(string cpf)
    {
        var pessoas = await _context.Pessoas
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.CPF.Equals(cpf));
        return Ok(pessoas);
    }

    [HttpPost]
    public async Task<IActionResult> Post(PessoaViewModel model)
    {
        var existsPessoa = await _context.Pessoas
        .AnyAsync(x => x.CPF.Equals(model.CPF));
        if (existsPessoa)
        {
            return BadRequest($"{model.Nome} já possui cadastro");
        }
        var pessoa = new Pessoa
        {
            Nome = model.Nome,
            CPF = model.CPF,
            Idade = model.Idade
        };

        _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();

        return Ok($"{model.Nome} foi cadastrada");
    }
}
