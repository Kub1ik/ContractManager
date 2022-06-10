using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractManager.Models
{
    public class Person
    {
        [Required(ErrorMessage = "First name is a required field.")]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field.")]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Age is a required field.")]
        [Range(18, 100, ErrorMessage = "Age must be in range between 18 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Personal id is a required field.")]
        [MaxLength(18, ErrorMessage = "Maximum length of personal id is 18 digits.")]
        [DisplayName("Personal Id")]
        public string? PersonalId { get; set; }

        [Required(ErrorMessage = "Phone number is a required field.")]
        [MaxLength(15, ErrorMessage = "Maximum length of phone number is 15 digits.")]
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        public string? Email { get; set; }
    }
}
