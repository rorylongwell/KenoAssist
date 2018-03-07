using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(KenoContext context) : base(context)
        {
            this.context = context;

        }
    }
}
