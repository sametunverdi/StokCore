using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokCore.EntityLayer.Concrete
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public int CategoryId { get; set; }

        // Navigation property - EF Core için önemli!
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
