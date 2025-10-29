using MediatR;

namespace MechanicalWorkShopWebApi.Application.Queries.Users
{
    public class GetUserWorkshopByIdQuery : IRequest<UserWorkshopViewModel?>
    {
        public int Id { get; set; }
    }
}
