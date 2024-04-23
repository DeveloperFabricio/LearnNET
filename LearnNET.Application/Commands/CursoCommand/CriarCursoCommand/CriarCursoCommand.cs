using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.CursoCommand.CriarCursoCommand
{
    public class CriarCursoCommand : IRequest<Unit>
    {
        public CursoDTO cursoDTO { get; set; }
    }
}
