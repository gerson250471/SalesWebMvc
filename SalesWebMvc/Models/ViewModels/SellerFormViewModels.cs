using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModels
    {
        public Seller seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
