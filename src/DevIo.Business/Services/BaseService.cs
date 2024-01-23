using DevIo.Business.Models;
using FluentValidation;

namespace DevIo.Business.Services
{
    public abstract class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) 
            where TV : AbstractValidator<TE> 
            where TE : Entity
        {
            validacao.Validate(entidade);

            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
                return true;

            return false;
        }
    }
}
