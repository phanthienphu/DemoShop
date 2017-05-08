using System;

namespace DemoShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DemoShopDbContext Init();
    }
}