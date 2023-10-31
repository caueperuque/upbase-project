using Microsoft.AspNetCore.Mvc;
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
    public IActionResult PostAluno([FromBody] Aluno aluno)
    {
        if (aluno != null)
        {
            _repository.InserirAluno(aluno);
            return Ok("Aluno cadastrado com sucesso");
        }

        return BadRequest("Erro no cadastro do aluno");
    }
}
