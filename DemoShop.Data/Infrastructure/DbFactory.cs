using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DemoShopDbContext dbContext;

        public DemoShopDbContext Init()
        {
            return dbContext ?? (dbContext = new DemoShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
