using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.User
{
    public interface IUserService
    {
        Task<List<AppUser>> GetAllUsers();
        Task CreateUser(AppUser appUser);
        void DeleteUser(AppUser appUser);
        void UpdateUser(AppUser appUser);
        Task<AppUser> GetUserById(int userId);
    }
}
