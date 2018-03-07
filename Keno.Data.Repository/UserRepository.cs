using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keno.Data.Contracts
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(KenoEntities context) : base(context)
        {
            this.context = context;

        }

        public List<User> GetUsersByUserTypeId(long userTypeId)
        {
            return context.Users.Where(m => m.UserTypeId == userTypeId).ToList();
        }
    }
}
