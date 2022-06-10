namespace ContractManager.Models
{
    public class ContractForEditViewModel
    {
        public Contract? Contract { get; set; }
        public IEnumerable<Adviser>? Advisers { get; set; }
        public List<int>? SelectedAdvisers { get; set; }
        public IEnumerable<Client>? Clients { get; set; }
    }
}
