using Arta.Framework.Domain.EqualityHelpers;

namespace Arta.Framework.Domain
{
    public abstract class ValueObject
    {
        public override bool Equals(object obj)
        {
            return EqualsBuilder.ReflectionEquals(this, obj);
        }

        public override int GetHashCode()
        {
            return HashCodeBuilder.ReflectionHashCode(this);
        }
    }
}