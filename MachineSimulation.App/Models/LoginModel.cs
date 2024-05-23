using System.ComponentModel.DataAnnotations;

namespace MachineSimulation.App.Models
{
    public class LoginModel
    {

        private string? _returnUrl;
        [Required]
        public  string?  Name { get; set; }
        [Required]
        public string Password { get; set; }

        public string? ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                {
                    return "/";
                }
                else
                {
                    return _returnUrl;
                }
            }
            set
            {
                _returnUrl = value;
            }
        }
    }
}
