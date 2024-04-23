using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.ModuloCommand.AtualizarModuloCommand
{
    public class AtualizarModuloCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public ModuloDTO moduloDTO { get; set; }
    }
}
