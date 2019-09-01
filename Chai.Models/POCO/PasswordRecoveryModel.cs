using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chai.Models.POCO
{
    public class PasswordRecoveryModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(maximumLength:32, MinimumLength =32, ErrorMessage = "Given code is incorrect")]
        public string Code { get; set; }
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$&*\^%\*\.])(?=.*[0-9])(?=.*[a-z]).{8,}$",
            ErrorMessage = "Password must have minimum 8 characters with at least one uppercase, lowercase, number and symbol")]
        public string Password { get; set; }
    }
}
