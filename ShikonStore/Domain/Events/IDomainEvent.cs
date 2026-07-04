using System;

namespace ShikonStore.Domain.Events
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
