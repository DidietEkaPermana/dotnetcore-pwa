using AppCore.DAL;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Repositories
{
    public class PoitemRepository : BaseRepository<Poitem>
    {
        public PoitemRepository(UTLogDbContext dbContext) : base(dbContext)
        {
        }
    }
}