using Exam3.Business.Repositories.Interfaces;
using Exam3.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Exam3.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        Exam3DbContext _context { get; }

        public GenericRepository(Exam3DbContext context)
        {
            _context = context;
        }

        DbSet<T> Table => _context.Set<T>();

        public IEnumerable<T> GetAll()
        {
            return Table;
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public void Insert(T model)
        {
            throw new NotImplementedException();
        }

        public void Create(T model)
        {
            Table.Add(model);
            Save();
        }

        public void Delete(int id)
        {
            var model = GetById(id);
            Table.Remove(model);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public T Update(int id)
        {
            return GetById(id);
        }
    }
}
