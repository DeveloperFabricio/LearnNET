using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.AssinaturaCommand.ExcluirAssinaturaCommand
{
    public class ExcluirAssinaturaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public AssinaturaDTO assinaturaDTO { get; set; }
    }
}
