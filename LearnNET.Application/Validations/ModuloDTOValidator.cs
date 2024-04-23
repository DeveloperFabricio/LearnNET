using FluentValidation;
using LearnNET.Application.DTO_s;

namespace LearnNET.Application.Validations
{
    public class ModuloDTOValidator : AbstractValidator<ModuloDTO>
    {
        public ModuloDTOValidator()
        {
            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.");

            RuleFor(dto => dto.Descricao)
                .NotEmpty().WithMessage("O campo Descrição é obrigatório.");

            RuleFor(dto => dto.DataCriacao)
                .GreaterThan(DateTime.MinValue).WithMessage("O campo Data de Criação é obrigatório.");
        }
    
    }
}
