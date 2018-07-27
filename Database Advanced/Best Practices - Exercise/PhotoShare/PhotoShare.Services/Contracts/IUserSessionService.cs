namespace PhotoShare.Services
{
    using Models;

    public interface IUserSessionService
    {
        User User { get; }

        User Login(string username, string password);

        void Logout();

        bool IsLoggedIn();
    }
}