using System;

namespace Sample.Models
{
    public class UserId
    {
        public Guid Id { get; set; }

        public UserId() => throw new ArgumentNullException();

        private UserId(Guid id)
        {
            Id = id;
        }

        public static UserId Create()
        {
            return new UserId(Guid.NewGuid());
        }

        public static UserId Empty()
        {
            return new UserId(Guid.Empty);
        }
    }
}