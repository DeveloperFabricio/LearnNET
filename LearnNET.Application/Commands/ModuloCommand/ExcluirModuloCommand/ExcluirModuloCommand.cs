using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.ModuloCommand.ExcluirModuloCommand
{
    public class ExcluirModuloCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public ModuloDTO moduloDTO { get; set; }
    }
}
