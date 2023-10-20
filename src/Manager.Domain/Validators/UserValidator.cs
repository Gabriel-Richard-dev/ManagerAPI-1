using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{

    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")
                .NotNull()
                .WithMessage("A entidade não pode ser nula.");


            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo")
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("O nome deve ter, no minimo, 3 caracteres")

                .MinimumLength(80)
                .WithMessage("O nome deve ter, no máximo, 80 caracteres");


            RuleFor(x => x.Email)
                .NotNull().WithMessage("O email não pode ser nulo")
                .NotEmpty().WithMessage("O email não pode ser vazio")
                .MinimumLength(13).WithMessage("O email deve ter no minimo 13 caracteres")
                .MaximumLength(180).WithMessage("O email deve ter no máximo 180 caracteres")

                .Matches(
                    @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                    )
                .WithMessage("O email informado não é válido");


            RuleFor(x => x.Password)
                .NotNull().WithMessage("A senha não pode ser nula")
                .NotEmpty().WithMessage("A senha não pode ser vazia")
                .MinimumLength(6).WithMessage("A senha deve ter, no minimo, 6 caracteres")
                .MaximumLength(30).WithMessage("A senha deve ter, no maximo, 30 caracteres");
        }
        
    }
    
    
    
    
}