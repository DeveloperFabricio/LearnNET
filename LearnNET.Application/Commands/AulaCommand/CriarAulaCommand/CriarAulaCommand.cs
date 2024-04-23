using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.AulaCommand.CriarAulaCommand
{
    public class CriarAulaCommand : IRequest<Unit>
    {
        public AulaDTO aulaDTO { get; set; }
    }
}
