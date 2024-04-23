using AutoMapper;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.UsuarioCommand.ExcluirUsuarioCommand
{
    public class ExcluirUsuarioCommandHandler : IRequestHandler<ExcluirUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public ExcluirUsuarioCommandHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Recuperar o usuário a ser excluído com base no ID
            var usuario = await _repository.ObterPorId(request.Id);

            if (usuario == null)
            {
                throw new NotFoundException($"Usuário com o ID {request.Id} não encontrado.");
            }

            // Excluir o usuário do repositório
            await _repository.Remover(usuario.Id);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}
