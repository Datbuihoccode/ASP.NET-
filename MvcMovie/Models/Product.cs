using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }              // Khóa chính
        public string Name { get; set; }         // Tên sản phẩm
        public decimal Price { get; set; }       // Giá
    }

}