using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetApi.Entities;

namespace DotNetApi.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}