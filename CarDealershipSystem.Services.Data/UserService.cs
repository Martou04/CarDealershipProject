namespace CarDealershipSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;
    
    using Interfaces;
    using Web.Data;
    using Web.ViewModels.User;
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

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(user => user.Id.ToString() == userId);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            List<UserViewModel> allUsers = await this.dbContext
               .Users
               .Select(u => new UserViewModel()
               {
                   Id = u.Id.ToString(),
                   Email = u.Email,
                   FullName = u.FirstName + " " + u.LastName
               })
               .ToListAsync();
            foreach (UserViewModel user in allUsers)
            {
                Seller? agent = this.dbContext
                    .Seller
                    .FirstOrDefault(a => a.UserId.ToString() == user.Id);
                if (agent != null)
                {
                    user.PhoneNumber = agent.PhoneNumber;
                }
                else
                {
                    user.PhoneNumber = string.Empty;
                }
            }

            return allUsers;
        }

    }
}
