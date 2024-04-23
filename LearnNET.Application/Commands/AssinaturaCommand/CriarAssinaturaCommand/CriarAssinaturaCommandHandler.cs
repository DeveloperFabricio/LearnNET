using AutoMapper;
using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.AssinaturaCommand.CriarAssinaturaCommand
{
    public class CriarAssinaturaCommandHandler : IRequestHandler<CriarAssinaturaCommand, Unit>
    {
        private readonly IAssinaturaRepository _repository;
        private readonly IMapper _mapper;

        public CriarAssinaturaCommandHandler(IAssinaturaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CriarAssinaturaCommand request, CancellationToken cancellationToken)
        {
            // Mapear o DTO para a entidade de assinatura
            var assinatura = _mapper.Map<Assinatura>(request.assinaturaDTO);

            // Salvar no repositório
            await _repository.Adicionar(assinatura);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}
