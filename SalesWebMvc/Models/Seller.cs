using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo {0} Obrigatório")]
        [StringLength(70, MinimumLength =3, ErrorMessage ="Tamanho do {0} deve ficar entre {2} e {1} caracteres")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Campo {0} Obrigatório")]
        [EmailAddress(ErrorMessage ="Entre com um {0} Valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} Obrigatório")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]    
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Campo {0} Obrigatório")]
        [Display(Name="Salário Base")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

         public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
