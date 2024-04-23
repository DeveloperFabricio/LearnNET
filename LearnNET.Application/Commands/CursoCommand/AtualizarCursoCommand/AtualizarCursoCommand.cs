using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.CursoCommand.AtualizarCursoCommand
{
    public class AtualizarCursoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public CursoDTO cursoDTO { get; set; }
    }
}
