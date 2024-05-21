using System.ComponentModel.DataAnnotations;

namespace WebAPI_CRUD_Feb1.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        public string? PName { get; set; }

        public int Price { get; set; }

        public DateTime DOP { get; set;}
    }
}
