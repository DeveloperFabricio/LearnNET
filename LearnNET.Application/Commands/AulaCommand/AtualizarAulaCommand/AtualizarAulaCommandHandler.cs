using AutoMapper;
using LearnNET.Core.Entities;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.AulaCommand.AtualizarAulaCommand
{
    public class AtualizarAulaCommandHandler : IRequestHandler<AtualizarAulaCommand, Unit>
    {
        private readonly IAulaRepository _repository;
        private readonly IMapper _mapper;

        public AtualizarAulaCommandHandler(IAulaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AtualizarAulaCommand request, CancellationToken cancellationToken)
        {
            var aulaExistente = await _repository.ObterPorId(request.Id);

            if (aulaExistente == null)
            {
                // Lançar exceção ou lidar com a situação de aula não encontrada
                throw new NotFoundException($"Assinatura com o ID {request.Id} não encontrada.");
            }

            // Mapear os dados do DTO para a entidade
            _mapper.Map(request.aulaDTO, aulaExistente);

            // Salvar no repositório
            await _repository.Atualizar(aulaExistente);

            return Unit.Value;
        }
    }
}
