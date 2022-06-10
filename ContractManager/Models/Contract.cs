using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractManager.Models
{
    public class Contract
    {
        [Column("ContractId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Registration number is a required field.")]
        [MaxLength(32, ErrorMessage = "Maximum length of registration number is 32 characters.")]
        [DisplayName("Registration Number")]
        public string? RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Institution is a required field.")]
        public string? Institution { get; set; }

        [Required(ErrorMessage = "Closing date is a required field.")]
        [DisplayName("Closing Date")]
        public DateTime ClosingDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Force date is a required field.")]
        [DisplayName("Force Date")]
        public DateTime ForceDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "End date is a required field")]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Client))]
        [DisplayName("Client Id")]
        public int ClientId { get; set; }
        public IList<ContractAdviser>? ContractAdvisers { get; set; }
    }
}
