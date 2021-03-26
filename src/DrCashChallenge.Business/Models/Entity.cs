using System;

namespace DrCashChallenge.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
