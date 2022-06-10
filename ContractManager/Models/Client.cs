using System.ComponentModel.DataAnnotations.Schema;

namespace ContractManager.Models
{
    public class Client : Person
    {
        [Column("ClientId")]
        public int Id { get; set; }
    }
}
