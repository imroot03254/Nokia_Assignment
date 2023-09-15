using BrokenAPI.Model;

namespace BrokenAPI.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetUsers(string sSearch);
    }
}
