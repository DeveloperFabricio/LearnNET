using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.AssinaturaCommand.CriarAssinaturaCommand
{
    public class CriarAssinaturaCommand : IRequest<Unit>
    {
        public AssinaturaDTO assinaturaDTO { get; set; }
    }
}
