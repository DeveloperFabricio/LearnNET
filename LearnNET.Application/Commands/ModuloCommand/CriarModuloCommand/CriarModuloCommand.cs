using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.ModuloCommand.CriarModuloCommand
{
    public class CriarModuloCommand : IRequest<Unit>
    {
        public ModuloDTO moduloDTO { get; set; }
    }
}
