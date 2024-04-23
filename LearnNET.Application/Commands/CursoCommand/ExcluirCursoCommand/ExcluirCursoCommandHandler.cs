using AutoMapper;
using LearnNET.Core.Exceptions;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.CursoCommand.ExcluirCursoCommand
{
    public class ExcluirCursoCommandHandler : IRequestHandler<ExcluirCursoCommand, Unit>
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public ExcluirCursoCommandHandler(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ExcluirCursoCommand request, CancellationToken cancellationToken)
        {
            // Recuperar o curso a ser excluído com base no ID
            var curso = await _cursoRepository.ObterPorId(request.Id);

            if (curso == null)
            {
                throw new NotFoundException($"Curso com o ID {request.Id} não encontrado.");
            }

            // Excluir o curso do repositório
            await _cursoRepository.Remover(curso.Id);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}
