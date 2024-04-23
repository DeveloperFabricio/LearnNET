using AutoMapper;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.AssinaturaCommand.AtualizarAssinaturaCommand
{
    public class AtualizarAssinaturaCommandHandler : IRequestHandler<AtualizarAssinaturaCommand, Unit>
    {
        private readonly IAssinaturaRepository _assinaturaRepository;
        private readonly IMapper _mapper;

        public AtualizarAssinaturaCommandHandler(IAssinaturaRepository assinaturaRepository, IMapper mapper)
        {
            _assinaturaRepository = assinaturaRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AtualizarAssinaturaCommand request, CancellationToken cancellationToken)
        {
            var assinaturaExistente = await _assinaturaRepository.ObterPorId(request.Id);

            if (assinaturaExistente == null)
            {
                // Lançar exceção ou lidar com a situação de assinatura não encontrada
                throw new NotFoundException($"Assinatura com o ID {request.Id} não encontrada.");
            }

            // Mapear os dados do DTO para a entidade
            _mapper.Map(request.assinaturaDTO, assinaturaExistente);

            // Salvar no repositório
            await _assinaturaRepository.Atualizar(assinaturaExistente);

            return Unit.Value;
        }
    }
}
