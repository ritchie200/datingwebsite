using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Setting
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
