using Arta.Framework.Core.Events;

namespace Arta.Framework.EF
{
    public class EntityCreated : IEvent
    {
        public EntityCreated(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}