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
            Table = _context.Set<T>();
        }
        DbSet<T> Table {  get; }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> data = Table.ToList();
            return (data);
        }

        public void Create(T model)
        {
            Table.Add(model);
            Save();
        }
        //public void Update(int id, T model)
        //{
        //    var data = GetById(id);
        //    data = model;
        //    Save();
        //}
        public void Delete(int id)
        {
            var model = Table.Find(id);
            Table.Remove(model);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }
    }
}
