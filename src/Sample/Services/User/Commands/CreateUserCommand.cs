using System;
using Sample.Interfaces.Commands;

namespace Sample.Services.User.Commands
{
    public class CreateUserCommand : ICommand
    {
        public Models.User User { get; set; }

        public CreateUserCommand() => throw new ArgumentNullException();
        public CreateUserCommand(Models.User user) => User = user;
    }
}