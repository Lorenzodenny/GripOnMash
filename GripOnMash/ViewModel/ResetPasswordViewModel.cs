namespace GripOnMash.ViewModel
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }

        public string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Le password non coincidono.")]
        public string ConfirmPassword { get; set; }
    }

}
