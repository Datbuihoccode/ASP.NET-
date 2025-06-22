using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models
{
    public class BookProduct : Product
    {
        public string Author { get; set; }
        
    }
}