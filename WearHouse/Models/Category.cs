using System.ComponentModel.DataAnnotations;

namespace WearHouse.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string CategoryName { get; set; }

    }
}
