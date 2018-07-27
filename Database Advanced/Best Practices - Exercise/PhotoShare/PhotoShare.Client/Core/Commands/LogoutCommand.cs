namespace PhotoShare.Client.Core.Commands
{
    using Contracts;
    using Services;

    public class LogoutCommand : ICommand
    {
        private readonly IUserSessionService userSessionService;

        public LogoutCommand(IUserSessionService userSessionService)
        {
            this.userSessionService = userSessionService;
        }

        public string Execute(params string[] arguments)
        {
            if (!userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            this.userSessionService.Logout();

            return "Logged out successfully!";
        }
    }
}