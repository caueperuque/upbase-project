using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using upbase_project.Models;
using upbase_project.Repository.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private IAlunoRepository _repository;

    public AlunosController(IAlunoRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult InserirAluno([FromBody] Aluno aluno)
    {
        var emailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
        if (!emailRegex.IsMatch(aluno.Email))
        {
            return BadRequest("Formato de email inválido");
        }

        var existEmail = _repository.GetAll().FirstOrDefault(a => a.Email == aluno.Email);
        if (existEmail != null)
        {
            return Conflict("Email já cadastrado!");
        }

        if (aluno != null) 
        {
            _repository.InserirAluno(aluno);
            return Ok("Aluno cadastrado com sucesso!");
        }

        return BadRequest("Erro no cadastro do aluno!");
    }
}
