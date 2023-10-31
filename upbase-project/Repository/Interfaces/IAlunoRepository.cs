using upbase_project.Models;

namespace upbase_project.Repository.Interfaces
{
    public interface IAlunoRepository
    {
        public IEnumerable<Aluno> GetAll();
        public void InserirAluno(Aluno aluno);
    }
}
