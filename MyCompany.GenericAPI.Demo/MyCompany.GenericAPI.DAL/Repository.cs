
using Microsoft.EntityFrameworkCore;
using MyCompany.GenericAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.GenericAPI.DAL
{

    //Scaffold-DbContext "Data Source=.;Initial Catalog=Temp;integrated security=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

    public interface IRepository<TEntity>
       where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        //Task Delete(int id);
    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TempContext _dbContext;

        public Repository(TempContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
       
    }
}
