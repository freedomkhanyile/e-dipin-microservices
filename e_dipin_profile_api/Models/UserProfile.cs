namespace e_dipin_profile_api.Models
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Cellphone { get; set; } // Sending sms.
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
    }
}