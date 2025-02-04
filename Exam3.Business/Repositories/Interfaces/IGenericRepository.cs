﻿
using Exam3.DAL.Contexts;

namespace Exam3.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel 
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Create(T model);
        public T Update(int id);
        public void Delete(int id);
        public void Save();
        public void Insert(T model);
    }
}
