using AppCore.DAL;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Repositories
{
    public class PoitemDetailRepository : BaseRepository<PoitemDetail>
    {
        public PoitemDetailRepository(UTLogDbContext dbContext) : base(dbContext)
        {
        }
    }
}