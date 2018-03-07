using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> GetUsersByUserTypeId(long userTypeId);
    }
}
