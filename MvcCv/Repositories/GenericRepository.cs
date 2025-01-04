using MvcCv.Data;
using System.Linq.Expressions;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }
        public void TAdd(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
        public void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Silinecek nesne null olamaz.");
            }

            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public T TGet(int id)
        {

            return _context.Set<T>().Find(id);

        }
        public void TUpdate(T item)
        {
            _context.SaveChanges();
        }
        
    }
}
