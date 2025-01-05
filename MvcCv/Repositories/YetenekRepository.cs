using MvcCv.Data;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class YetenekRepository :GenericRepository<TblYeteneklerim>
    {
        public YetenekRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
