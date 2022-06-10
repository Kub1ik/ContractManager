namespace ContractManager.Models
{
    public class ContractForCreationViewModel
    {
        public IEnumerable<Client>? Clients { get; set; }
        public IEnumerable<Adviser>? Advisers { get; set; }
        public Contract? Contract { get; set; }
        public List<int>? SelectedAdviserIds { get; set; }
    }
}
