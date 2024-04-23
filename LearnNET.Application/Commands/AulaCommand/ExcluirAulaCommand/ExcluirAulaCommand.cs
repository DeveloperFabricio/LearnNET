using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.AulaCommand.ExcluirAulaCommand
{
    public class ExcluirAulaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public AulaDTO aulaDTO { get; set; }
    }
}
