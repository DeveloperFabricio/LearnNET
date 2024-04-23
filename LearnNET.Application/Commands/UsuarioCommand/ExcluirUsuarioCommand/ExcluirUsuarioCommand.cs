using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.UsuarioCommand.ExcluirUsuarioCommand
{
    public class ExcluirUsuarioCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UsuarioDTO usuarioDTO { get; set; }
    }
}
