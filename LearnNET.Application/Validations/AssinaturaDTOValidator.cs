﻿using FluentValidation;
using LearnNET.Application.DTO_s;

namespace LearnNET.Application.Validations
{
    public class AssinaturaDTOValidator : AbstractValidator<AssinaturaDTO>
    {
        public AssinaturaDTOValidator()
        {
            RuleFor(dto => dto.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.");

            RuleFor(dto => dto.Duracao)
                .GreaterThan(0).WithMessage("A Duração deve ser maior que zero.");
        }
    }
}
