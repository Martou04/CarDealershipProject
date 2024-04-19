namespace CarDealershipSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using Interfaces;
    using Web.Data;
    using CarDealershipSystem.Data.Models;
    public class UserService : IUserService
    {
        private readonly CarDealershipDbContext dbContext;

        public UserService(CarDealershipDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(user => user.Email == email);

            if(user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
