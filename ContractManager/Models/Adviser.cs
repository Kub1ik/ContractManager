using System.ComponentModel.DataAnnotations.Schema;

namespace ContractManager.Models
{
    public class Adviser : Person
    {
        [Column("AdviserId")]
        public int Id { get; set; }
        public IList<ContractAdviser>? ContractAdvisers { get; set; }
    }
}
