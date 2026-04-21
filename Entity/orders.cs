using System.ComponentModel.DataAnnotations;
namespace entityframeworkcodebaseapproachwithdiftdb.Entity
{
    public class orders
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderStatus { get; set; }
        public string ordername { get; set; }
    }
}
