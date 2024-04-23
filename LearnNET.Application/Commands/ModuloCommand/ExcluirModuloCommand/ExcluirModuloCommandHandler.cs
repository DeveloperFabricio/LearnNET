using AutoMapper;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.ModuloCommand.ExcluirModuloCommand
{
    public class ExcluirModuloCommandHandler : IRequestHandler<ExcluirModuloCommand, Unit>
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IMapper _mapper;

        public ExcluirModuloCommandHandler(IModuloRepository moduloRepository, IMapper mapper)
        {
            _moduloRepository = moduloRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ExcluirModuloCommand request, CancellationToken cancellationToken)
        {
            // Recuperar o módulo a ser excluído com base no ID
            var modulo = await _moduloRepository.ObterPorId(request.Id);

            if (modulo == null)
            {
                throw new NotFoundException($"Módulo com o ID {request.Id} não encontrado.");
            }

            // Excluir o módulo do repositório
            await _moduloRepository.Remover(modulo.Id);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}
