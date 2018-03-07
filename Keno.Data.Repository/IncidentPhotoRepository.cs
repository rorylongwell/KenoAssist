﻿using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public class IncidentPhotoRepository : Repository<IncidentPhoto>, IIncidentPhotoRepository
    {
        public IncidentPhotoRepository(KenoContext context) : base(context)
        {
            this.context = context;

        }
    }
}
