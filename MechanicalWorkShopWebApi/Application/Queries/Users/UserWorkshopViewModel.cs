namespace MechanicalWorkShopWebApi.Application.Queries.Users
{
    public class UserWorkshopViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
        public string PrimaryNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
