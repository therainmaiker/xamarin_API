using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Xamarin.Models
{
    public class Images
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }

        [JsonIgnore] public Product ProductImg { get; set; }

        public byte[] Image { get; set; }
        public string ProductImgId { get; set; }
    }
}
