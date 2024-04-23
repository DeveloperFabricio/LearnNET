using AutoMapper;
using LearnNET.Core.Entities;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.UsuarioCommand.AtualizarUsuarioCommand
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public AtualizarUsuarioCommandHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Recuperar o usuário a ser atualizado com base no ID
            var usuario = await _repository.ObterPorId(request.Id);

            if (usuario == null)
            {
                throw new NotFoundException($"Usuário com o ID {request.Id} não encontrado.");
            }

            // Mapear o DTO para a entidade Usuário
            var usuarioAtualizado = _mapper.Map<Usuario>(request.usuarioDTO);

            // Atualizar os dados do usuário
            usuario.NomeCompleto = usuarioAtualizado.NomeCompleto;
            usuario.Email = usuarioAtualizado.Email;
            usuario.Senha = usuarioAtualizado.Senha; // Lembre-se de implementar a lógica apropriada para atualização de senhas, como hash e salting
            usuario.DataNascimento = usuarioAtualizado.DataNascimento;
            usuario.Documento = usuarioAtualizado.Documento;
            usuario.Celular = usuarioAtualizado.Celular;

            // Atualizar o usuário no repositório
            await _repository.Atualizar(usuario);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}
