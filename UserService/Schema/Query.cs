using UserService.Data;

namespace UserService.Schema
{
    public class Query
    {
        public User GetUser(int id, [Service] ApplicationDbContext context)
        {
            return context.Users
                            .Where(u => u.Id == id)
                            .FirstOrDefault();
        }
    }
}
