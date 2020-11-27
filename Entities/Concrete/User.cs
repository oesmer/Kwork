using Kwork.Core.Entities.Abstract;

namespace Kwork.Entities.Concrete
{
    public class User : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public string UserName { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
