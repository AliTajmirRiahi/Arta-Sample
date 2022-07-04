using Arta.Framework.Domain.Exceptions;

namespace Arta.Framework.Domain
{
    public static class DomainValidatorExtensions
    {
        public static void Validate(this IDomainValidator validator)
        {
            if (!validator.IsValid)
                throw new ValidationFailedException();
        }
    }
}