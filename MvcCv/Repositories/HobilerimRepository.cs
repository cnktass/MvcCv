using MvcCv.Data;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class HobilerimRepository : GenericRepository<TblHobilerim>
    {
        public HobilerimRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
