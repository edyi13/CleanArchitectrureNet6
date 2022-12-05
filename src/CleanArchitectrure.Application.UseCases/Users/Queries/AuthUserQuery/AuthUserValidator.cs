using FluentValidation;

namespace CleanArchitectrure.Application.UseCases.Users.Queries.AuthUserQuery
{
    public class AuthUserValidator : AbstractValidator<AuthUserQuery>
    {
        public AuthUserValidator()
        {
            RuleFor(x => x.Client).NotNull().NotEmpty();
            RuleFor(x => x.Secret).NotNull().NotEmpty().MinimumLength(6);
        }
    }
}
