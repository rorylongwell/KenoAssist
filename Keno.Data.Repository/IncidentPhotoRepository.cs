using Keno.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keno.Data.Contracts
{
    public class IncidentPhotoRepository : Repository<IncidentPhoto>, IIncidentPhotoRepository
    {
        public IncidentPhotoRepository(KenoEntities context) : base(context)
        {
            this.context = context;

        }

        public List<IncidentPhoto> GetIncidentPhotosByIncidentId(long incidentId)
        {
            return context.IncidentPhotos.Where(i => i.IncidentId == incidentId).ToList();
        }
    }
}
