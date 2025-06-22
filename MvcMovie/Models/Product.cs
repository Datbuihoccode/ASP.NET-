using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models
{
    [Table("Product")]
    public class Product
    {
        private string _name;
        private decimal _price;
        
        [Key]
        public int Id { get; set; }   // Khóa chính
        public string Category{ get; set; }          
        public string Name// Tên sản phẩm
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên sản phẩm không được để trống");
                }
                _name = value;
            }
        }        

        public decimal Price// Giá
        {
            get => _price;
            set
            {
                if (value < 0)
                { throw new ArgumentOutOfRangeException("Giá trị không hợp lệ"); }
                _price = value;
            }
        }       
    }
}