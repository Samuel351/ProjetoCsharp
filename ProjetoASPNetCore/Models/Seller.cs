using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetoASPNetCore.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime birthDate { get; set; }

        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double baseSalary { get; set; }

        [Display(Name = "Departamento")]
        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        { }

        public Seller(string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Name = name;
            Email = email;
            this.birthDate = birthDate;
            this.baseSalary = baseSalary;
            Departament = departament;
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            this.birthDate = birthDate;
            this.baseSalary = baseSalary;
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
