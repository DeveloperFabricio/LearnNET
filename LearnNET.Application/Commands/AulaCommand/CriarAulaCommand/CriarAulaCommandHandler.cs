using AutoMapper;
using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.AulaCommand.CriarAulaCommand
{
    public class CriarAulaCommandHandler : IRequestHandler<CriarAulaCommand, Unit>
    {
        private readonly IAulaRepository _repository;
        private readonly IMapper _mapper;

        public CriarAulaCommandHandler(IAulaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CriarAulaCommand request, CancellationToken cancellationToken)
        {
            // Mapear o DTO para a entidade de aula
            var aula = _mapper.Map<Aula>(request.aulaDTO);

            // Adicionar a aula ao repositório
            await _repository.Adicionar(aula);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}
