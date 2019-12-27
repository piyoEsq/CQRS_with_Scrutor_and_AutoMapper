using System;

namespace Sample.Models
{
    public class User
    {
        public UserId Id { get; set; }
        public UserName Name { get; set; }

        public User() => throw new ArgumentNullException();
        private User(UserId id, UserName name)
        {
            Id = id;
            Name = name;
        }

        public static User Create(UserId id, UserName name)
        {
            return new User(id, name);
        }

        public static User Empty()
        {
            return new User(UserId.Empty(), UserName.Empty());
        }
    }
}