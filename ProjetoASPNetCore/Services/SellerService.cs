using ProjetoASPNetCore.Data;
using ProjetoASPNetCore.Models;

namespace ProjetoASPNetCore.Services
{
    public class SellerService
    {

        private readonly ProjetoASPNetCoreContext _context;

        public SellerService(ProjetoASPNetCoreContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
