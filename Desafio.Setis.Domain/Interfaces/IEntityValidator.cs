using Desafio.Setis.Domain.Context;
using FluentValidation.Results;

namespace Desafio.Setis.Domain.Interfaces
{
    public interface IEntityValidator
    {
        ValidationResult Validate(ValidatorContext context);
    }

}
