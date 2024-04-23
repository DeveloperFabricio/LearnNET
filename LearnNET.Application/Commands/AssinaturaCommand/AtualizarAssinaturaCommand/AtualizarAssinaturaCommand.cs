using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.AssinaturaCommand.AtualizarAssinaturaCommand
{
    public class AtualizarAssinaturaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public AssinaturaDTO assinaturaDTO { get; set; }
    }
}
