using APBD_TASK2.Database;

namespace APBD_TASK2.Models;

public class UserService
{
    private readonly Singleton _db = Singleton.Instance;

    public void AddUser(User user)
    {
        _db.Users.Add(user);
    }

    public User GetUser(int userId)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) throw new Exception("User not found.");
        return user;
    }

    public List<User> GetAllUsers()
    {
        return _db.Users.ToList();
    }
}