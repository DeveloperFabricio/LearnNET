using AutoMapper;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.AssinaturaCommand.ExcluirAssinaturaCommand
{
    public class ExcluirAssinaturaCommandHandler : IRequestHandler<ExcluirAssinaturaCommand, Unit>
    {
        private readonly IAssinaturaRepository _assinaturaRepository;
        private readonly IMapper _mapper;

        public ExcluirAssinaturaCommandHandler(IAssinaturaRepository assinaturaRepository, IMapper mapper)
        {
            _assinaturaRepository = assinaturaRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ExcluirAssinaturaCommand request, CancellationToken cancellationToken)
        {
            // Recuperar a assinatura a ser excluída com base no ID
            var assinatura = await _assinaturaRepository.ObterPorId(request.Id);

            if (assinatura == null)
            {
                throw new NotFoundException($"Assinatura com o ID {request.Id} não encontrada.");
            }

            // Excluir a assinatura do repositório
            await _assinaturaRepository.Remover(assinatura.Id);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    
    }
}
