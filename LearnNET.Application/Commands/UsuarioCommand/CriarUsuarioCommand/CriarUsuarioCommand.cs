using LearnNET.Application.DTO_s;
using MediatR;

namespace LearnNET.Application.Commands.UsuarioCommand.CriarUsuarioCommand
{
    public class CriarUsuarioCommand : IRequest<Unit>
    {
        public UsuarioDTO usuarioDTO { get; set; }
    }
}
