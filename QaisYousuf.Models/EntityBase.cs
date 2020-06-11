using System.ComponentModel.DataAnnotations;

namespace QaisYousuf.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

    }
}
