using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BasketballContext dbContext;

        public BasketballContext Init()
        {
            return dbContext ?? (dbContext = new BasketballContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
