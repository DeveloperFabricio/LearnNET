using AutoMapper;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.AulaCommand.ExcluirAulaCommand
{
    public class ExcluirAulaCommandHandler : IRequestHandler<ExcluirAulaCommand, Unit>
    {
        private readonly IAulaRepository _repository;
        private readonly IMapper _mapper;

        public ExcluirAulaCommandHandler(IAulaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ExcluirAulaCommand request, CancellationToken cancellationToken)
        {
            // Recuperar a aula a ser excluída com base no ID
            var aula = await _repository.ObterPorId(request.Id);

            if (aula == null)
            {
                throw new NotFoundException($"Aula com o ID {request.Id} não encontrada.");
            }

            // Excluir a aula do repositório
            await _repository.Remover(aula.Id);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}
