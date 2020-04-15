using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingStore.DataAccess.Context;

namespace GamingStore.Repository.Infrastructure.Concrete
{
    public class EfBaseRepository
    {
        public ProjectContext db;
        public EfBaseRepository()
        {
            db = new ProjectContext();
        }
    }
}
