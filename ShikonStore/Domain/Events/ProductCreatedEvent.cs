using System;
using ShikonStore.Domain.Agregates;

namespace ShikonStore.Domain.Events
{
    public class ProductCreatedEvent : IDomainEvent
    {
        public Product Product { get; }
        public DateTime OccurredOn { get; }

        public ProductCreatedEvent(Product product)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            OccurredOn = DateTime.UtcNow;
        }
    }
}
