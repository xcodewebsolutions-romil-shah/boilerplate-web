using Boilerplate.Data.Domains;
using Boilerplate.Infrastructure.Dtos;

namespace Boilerplate.Infrastructure.Mapping
{
    public partial class Map
    {
        public static UserDto EntityToDto(User user)
        {
            return new UserDto
            {
                LastName = user.LastName,
                Username = user.Username,
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                UserID = user.UserID,
                Password = user.Password

            };
        }
    }
}
