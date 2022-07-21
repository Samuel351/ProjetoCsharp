using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetoASPNetCore.Models
{
    public class Seller
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres e no máximo 60")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório!")]
        [EmailAddress(ErrorMessage = "Coloque um e-mail válido!")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatório!")]
        [Display(Name = "Data de nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Salário é obrigatório!")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve ser de {1} até {2}")]
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        [Display(Name = "Departamento")]
        public Departament? Departament { get; set; }
        public int? DepartamentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        { 
        }

        public Seller(string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void addSales(SalesRecord record)
        {
            Sales.Add(record);
        }

        public void removeSales(SalesRecord record)
        {
            Sales.Remove(record);
        }

        public double totalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(record => record.Date >= initial && record.Date <= final).Sum(record => record.Amount);
        }
    }
}
