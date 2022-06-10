namespace ContractManager.Models
{
    public class AdviserContractViewModel
    {
        public Adviser? Adviser { get; set; }
        public Contract? Contract { get; set; }
        public IEnumerable<ContractAdviser>? ContractAdviser { get; set; }
    }
}
