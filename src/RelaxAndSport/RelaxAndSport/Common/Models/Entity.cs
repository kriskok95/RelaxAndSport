using System.Collections.Generic;
using System.Linq;

namespace RelaxAndSport.Domain.Common.Models
{
    public abstract class Entity<TId>
        where TId : struct
    {
        private readonly ICollection<IDomainEvent> events;

        protected Entity() => this.events = new List<IDomainEvent>();

        public TId Id { get; private set; } = default;

        public IReadOnlyCollection<IDomainEvent> Events
            => this.events.ToList().AsReadOnly();

        public void ClearEvents() => this.events.Clear();

        protected void RaiseEvent(IDomainEvent domainEvent)
            => this.events.Add(domainEvent);

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity<TId> other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            if (Id.Equals(default) || other.Id.Equals(default))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
        {
            if (first is null && second is null)
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Entity<TId>? first, Entity<TId>? second) => !(first == second);

        public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();
    }
}
