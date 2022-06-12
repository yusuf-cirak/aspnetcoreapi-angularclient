using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SehirRehberi.Models;

namespace SehirRehberi.Business.Abstract
{
    public interface IAuthRepositoryService
    {
        Task<User> Register(User user, string password);

        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}
