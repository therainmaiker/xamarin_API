using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Xamarin.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        [JsonIgnore] public Category ProductCategory { get; set; }
        public string ProductCategoryId { get; set; }

       

        [JsonIgnore] public List<Images> ProductImages { get; set; }
    }
}
