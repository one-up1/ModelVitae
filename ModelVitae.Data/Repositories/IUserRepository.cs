using ModelVitae.Data.Models;

namespace ModelVitae.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByGoogleId(string googleId);
    }
}