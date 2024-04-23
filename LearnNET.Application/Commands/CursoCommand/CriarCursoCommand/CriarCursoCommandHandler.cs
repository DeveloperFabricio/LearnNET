using AutoMapper;
using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Commands.CursoCommand.CriarCursoCommand
{
    public class CriarCursoCommandHandler : IRequestHandler<CriarCursoCommand, Unit>
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public CriarCursoCommandHandler(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CriarCursoCommand request, CancellationToken cancellationToken)
        {
            // Mapear o DTO para a entidade Curso
            var curso = _mapper.Map<Curso>(request.cursoDTO);

            // Adicionar o curso ao repositório
            await _cursoRepository.Adicionar(curso);

            // Retornar uma unidade como resultado
            return Unit.Value;
        }
    }
}
