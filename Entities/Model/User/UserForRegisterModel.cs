using Core.Entities;

namespace Entities.Model.User
{
    public class UserForRegisterModel : IModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
