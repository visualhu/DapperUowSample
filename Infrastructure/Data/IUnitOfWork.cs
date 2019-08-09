using System;

namespace Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        //IContext DbContext { get; set; }
        void SaveChanges();
    }
}
