using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractManager.Models
{
    public class ContractAdviser
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Contract))]
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }


        [ForeignKey(nameof(Adviser))]
        public int AdviserId { get; set; }
        public Adviser? Adviser { get; set; }
    }
}