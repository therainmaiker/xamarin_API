using Api_Xamarin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Xamarin.Models
{

    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public byte[] Image { get; set; }

        //public string Url { get; set; }
        [JsonIgnore] public List<Product> Products { get; set; }
    }
}

