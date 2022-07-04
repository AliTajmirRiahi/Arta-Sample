using Arta.Framework.Domain;

namespace Arta.Framework.EF
{
    public class Audit : Entity<long>
    {
        public string AggregateRootName { get; set; }

        public string Values { get; set; }
    }
}