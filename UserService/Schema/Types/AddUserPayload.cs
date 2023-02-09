using UserService.Data;

namespace UserService.Schema.Types
{
    public class AddUserPayload
    {
        public User User { get; }

        public AddUserPayload(User user)
        {
            User = user;
        }
    }
}
