using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppCore.Models;

namespace AppCore.BLL
{
    public class PoManager
    {
        IUnitOfWork reps;
        public PoManager(IUnitOfWork _reps)
        {
            reps = _reps;
        }
        public async Task<IEnumerable<Poheader>> GetHeader()
        {
            return await reps.PoheaderRepository.GetAsync();
        }
        public async Task<IEnumerable<Poitem>> GetItem(long OrderId)
        {
            return await reps.PoitemRepository.GetAsync(p => p.OrderId == OrderId);
        }
        public async Task<IEnumerable<PoitemDetail>> GetItemDetail(long OrderItemId)
        {
            return await reps.PoitemDetailRepository.GetAsync(p => p.OrderItemId == OrderItemId);
        }
    }
}