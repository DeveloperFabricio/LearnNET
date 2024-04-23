using FluentValidation;
using LearnNET.Application.DTO_s;

namespace LearnNET.Application.Validations
{
    public class UsuarioDTOValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioDTOValidator()
        {
            RuleFor(dto => dto.NomeCompleto)
                .NotEmpty().WithMessage("O campo Nome Completo é obrigatório.");

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("O campo Email é obrigatório.")
                .EmailAddress().WithMessage("O campo Email deve ser um endereço de email válido.");

            RuleFor(dto => dto.Documento)
                .NotEmpty().WithMessage("O campo Documento é obrigatório.");

            RuleFor(dto => dto.Celular)
            .NotEmpty().WithMessage("O campo Celular é obrigatório.")
            .Matches(@"^\d{10,11}$").WithMessage("O campo Celular deve conter apenas números e ter entre 10 e 11 dígitos.");
        }
    }
 
}
