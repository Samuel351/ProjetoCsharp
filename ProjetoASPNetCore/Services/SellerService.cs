using ProjetoASPNetCore.Data;
using ProjetoASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Seller.Include(obj => obj.Departament).ToList();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id); 
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
