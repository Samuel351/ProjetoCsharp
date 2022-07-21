using ProjetoASPNetCore.Data;
using ProjetoASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoASPNetCore.Services
{
    public class SalesRecordService
    {
        private readonly ProjetoASPNetCoreContext _context;

        public SalesRecordService(ProjetoASPNetCoreContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if(minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if(maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Departament)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }
    }
}
