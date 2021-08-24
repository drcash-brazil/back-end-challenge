

namespace BackEnd.Models
{
    public class Users:Base
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }="user";
    }
}