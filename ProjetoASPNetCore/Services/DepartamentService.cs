using ProjetoASPNetCore.Data;
using ProjetoASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoASPNetCore.Services
{
    public class DepartamentService
    {


        private readonly ProjetoASPNetCoreContext _context;

        public DepartamentService(ProjetoASPNetCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Departament>> FindAllAsync()
        {
            return await _context.Departament.OrderBy(x => x.Name).ToListAsync();
        }

    }
}
