using MechanicalWorkShopWebApi.Application.Queries.Users;
using MechanicalWorkShopWebApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mechanical_workshop.Application.Queries.Users
{
    public class GetUserWorkshopByIdQueryHandler : IRequestHandler<GetUserWorkshopByIdQuery, UserWorkshopViewModel?>
    {
        private readonly WorkshopDbContext _context;

        public GetUserWorkshopByIdQueryHandler(WorkshopDbContext context)
        {
            _context = context;
        }

        public async Task<UserWorkshopViewModel?> Handle(GetUserWorkshopByIdQuery request, CancellationToken cancellationToken)
        {

            var userViewModel = await _context.UsersWorkshop
                .AsNoTracking()
                .Where(u => u.Id == request.Id)
                .Select(u => new UserWorkshopViewModel
                {
                    Id = u.Id,
                    FullName = u.Name + " " + u.LastName,
                    Email = u.Email,
                    Profile = u.Profile,
                    PrimaryNumber = u.PrimaryNumber,
                    FullAddress = u.Address + ", " + u.City + ", " + u.State + " " + u.Zip
                })
                .FirstOrDefaultAsync(cancellationToken);

            return userViewModel;
        }
    }
}