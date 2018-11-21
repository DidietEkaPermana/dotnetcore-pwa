using System;
using AppCore.Interfaces;
using AppCore.Repositories;

namespace AppCore.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Base
        private UTLogDbContext dbContext;
        private bool disposed = false;

        public UnitOfWork(UTLogDbContext context)
        {
            this.dbContext = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion Base

        private LogsRepository logsRepository;
        public LogsRepository LogsRepository
        {
            get
            {
                if(this.logsRepository == null)
                {
                    this.logsRepository = new LogsRepository(dbContext);
                }

                return this.logsRepository;
            }
        }
        private PoheaderRepository poheaderRepository;
        public PoheaderRepository PoheaderRepository
        {
            get
            {
                if(this.poheaderRepository == null)
                {
                    this.poheaderRepository = new PoheaderRepository(dbContext);
                }

                return this.poheaderRepository;
            }
        }
        private PoitemRepository poitemRepository;
        public PoitemRepository PoitemRepository
        {
            get
            {
                if(this.poitemRepository == null)
                {
                    this.poitemRepository = new PoitemRepository(dbContext);
                }

                return this.poitemRepository;
            }
        }
        private PoitemDetailRepository poitemDetailRepository;
        public PoitemDetailRepository PoitemDetailRepository
        {
            get
            {
                if(this.poitemDetailRepository == null)
                {
                    this.poitemDetailRepository = new PoitemDetailRepository(dbContext);
                }

                return this.poitemDetailRepository;
            }
        }
    }
}