using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.AulaCommand.AtualizarAulaCommand
{
    public class AtualizarAulaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public AulaDTO aulaDTO { get; set; }
    }
}
