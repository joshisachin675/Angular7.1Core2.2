using IDCardScanning.Model.Enums;

namespace IDCardScanning.Model.Models
{
    public class SignedInModel
    {
        public long UserId { get; set; }

        public Roles Roles { get; set; }
    }
}
