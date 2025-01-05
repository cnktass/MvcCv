using MvcCv.Data;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class HakkimdaRepository : GenericRepository<TblHakkimda>
    {
        public HakkimdaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
