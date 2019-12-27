using System;

namespace Sample.Models
{
    public class UserName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public UserName() => throw new ArgumentNullException();
        private UserName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}";
        }

        public static UserName Create(string firstName, string lastName)
        {
            return new UserName(firstName, lastName);
        }

        internal static UserName Empty()
        {
            return new UserName(string.Empty, string.Empty);
        }
    }
}