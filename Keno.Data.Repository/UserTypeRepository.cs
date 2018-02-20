﻿using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(KenoEntities context) : base(context)
        {
            this.context = context;

        }
    }
}
