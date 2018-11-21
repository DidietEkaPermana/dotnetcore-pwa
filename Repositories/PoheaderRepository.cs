using AppCore.DAL;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Repositories
{
    public class PoheaderRepository : BaseRepository<Poheader>
    {
        public PoheaderRepository(UTLogDbContext dbContext) : base(dbContext)
        {
        }
    }
}