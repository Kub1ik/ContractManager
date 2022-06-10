namespace ContractManager.Models
{
    public class ClientContractViewModel
    {
        public Client? Client { get; set; }
        public IEnumerable<Contract>? Contracts { get; set; }
    }
}
