using ProjetoASPNetCore.Data;
using ProjetoASPNetCore.Models;

namespace ProjetoASPNetCore.Services
{
    public class DepartamentService
    {


        private readonly ProjetoASPNetCoreContext _context;

        public DepartamentService(ProjetoASPNetCoreContext context)
        {
            _context = context;
        }

        public List<Departament> FindAll()
        {
            return _context.Departament.OrderBy(x => x.Name).ToList();
        }

    }
}
