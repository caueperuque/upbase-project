using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using upbase_project.Context;
using upbase_project.Models;
using upbase_project.Repository.Interfaces;

public class AlunoRepository : IAlunoRepository
{
    private readonly AppDbContext _context;

    public AlunoRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Aluno> GetAll()
    {
        return _context.Alunos.ToList();
    }

    public void InserirAluno(Aluno aluno)
    {
        if (aluno != null)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }
    }
}
