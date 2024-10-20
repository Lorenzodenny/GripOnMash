namespace GripOnMash.ViewModel
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; } 
    }

}
