using AutoMapper;
using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.UsuarioCommand.CriarUsuarioCommand
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public CriarUsuarioCommandHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Mapear o DTO para a entidade Usuário
            var usuario = _mapper.Map<Usuario>(request.usuarioDTO);

            // Adicionar o usuário ao repositório
            await _repository.Adicionar(usuario);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}
