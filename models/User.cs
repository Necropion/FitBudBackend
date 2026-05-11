using System.ComponentModel.DataAnnotations;

namespace Backend.models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public int Role_id { get; set; } = default!;

        [Required]
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
    }
}