using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.UsuarioCommand.AtualizarUsuarioCommand
{
    public class AtualizarUsuarioCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UsuarioDTO usuarioDTO { get; set; }
    }
}
