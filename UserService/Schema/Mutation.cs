using UserService.Data;
using UserService.Schema.Types;

namespace UserService.Schema
{
    public class Mutation
    {
        public async Task<AddUserPayload> AddUserAsync(AddUserInput input, [Service] ApplicationDbContext context)
        {
            var user = new User
            {
                DisplayName = input.DisplayName,
                SocialHandle = input.SocialHandle,
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new AddUserPayload(user);
        }
    }
}
