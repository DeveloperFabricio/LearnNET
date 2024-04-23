using AutoMapper;
using LearnNET.Application.DTO_s;
using LearnNET.Core.Repositories;
using MediatR;

namespace LearnNET.Application.Queries.UsuarioQuery.ObterTodosUsuariosQuery
{
    public class ObterTodosUsuariosQueryHandler : IRequestHandler<ObterTodosUsuariosQuery, List<UsuarioDTO>>
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IMapper _mapper;

        public ObterTodosUsuariosQueryHandler(IUsuarioRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> Handle(ObterTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _userRepository.ObterTodos();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }
    }
}
