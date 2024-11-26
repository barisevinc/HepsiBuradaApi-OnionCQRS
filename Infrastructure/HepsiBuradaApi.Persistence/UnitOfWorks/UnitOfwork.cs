using HepsiBuradaApi.Application.Interfaces.Repositories;
using HepsiBuradaApi.Application.UnitOfWorks;
using HepsiBuradaApi.Persistence.Context;
using HepsiBuradaApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Persistence.UnitOfWorks
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfwork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async ValueTask DisposeAsync() => await _appDbContext.DisposeAsync();


        public int Save() => _appDbContext.SaveChanges();
        public async Task<int> SaveAsync() => await _appDbContext.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_appDbContext);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_appDbContext);

    }
}
