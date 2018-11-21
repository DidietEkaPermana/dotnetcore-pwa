using AppCore.DAL;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Repositories
{
    public class LogsRepository : BaseRepository<Logs>
    {
        public LogsRepository(UTLogDbContext dbContext) : base(dbContext)
        {
        }
    }
}