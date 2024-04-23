using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.CursoQuery.ObterTodosCursosQuery
{
    public class ObterTodosCursosQueryHandler : IRequestHandler<ObterTodosCursosQuery, List<CursoDTO>>
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public ObterTodosCursosQueryHandler(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<List<CursoDTO>> Handle(ObterTodosCursosQuery request, CancellationToken cancellationToken)
        {
            var cursos = await _cursoRepository.ObterTodos();
            return _mapper.Map<List<CursoDTO>>(cursos);
        }
    }
}
