using System.ComponentModel.DataAnnotations;

namespace Backend.models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;
    }
}