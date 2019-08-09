using Infrastructure.Data;
using System;

namespace Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;
        public UnitOfWork(IContext context)
        {
            _context = context;
        }

        //protected IContext DbContext
        //{
        //    get; set;
        //}

        public void SaveChanges()
        {
            if (!_context.IsTransactionStarted)
            {
                throw new InvalidOperationException("Thransaction have already been commited or disposed.");
            }

            _context.Commit();
        }

        public void Dispose()
        {
            if (!_context.IsTransactionStarted)
            {
                _context.Dispose();
            }
        }
    }
}
