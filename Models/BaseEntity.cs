using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
