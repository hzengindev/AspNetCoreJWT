using System;

namespace Business.Model.Auth
{
    public class LoginOutModel : BaseOutModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
}
