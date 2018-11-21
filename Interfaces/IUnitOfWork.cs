using System;
using AppCore.Repositories;

namespace AppCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        LogsRepository LogsRepository { get; }
        PoheaderRepository PoheaderRepository { get; }
        PoitemRepository PoitemRepository { get; }
        PoitemDetailRepository PoitemDetailRepository { get; }

        new void Dispose();
    }
}