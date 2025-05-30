using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Data;

namespace MvcMovie.Controllers
{
    [Route("api/[controller]")]//xác định URL cơ bản cho các endpoint
    [ApiController]//đây là một API controller
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Product/READ
        // public async Task<IActionResult> Index()
        // {
        //     var model = await _context.Product.ToListAsync();
        //     return View(model);
        // }

        // //GET: Product/CREATE (trả về view form Create)
        // public IActionResult Create()
        // {
        //     return View();
        // }
        // //POST: Product/CREATE
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create(Product product)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(product);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(product);  // Nếu ModelState không hợp lệ, quay lại form Create
        // }

        //GET api/Product
        [HttpGet] //READ
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()//Hiện thông tin toàn bộ sản phẩm 
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")] //READ
        public async Task<ActionResult<Product>> GetProduct(int id)//Lấy thông tin sản phẩm theo ID
        {
            var product = await _context.Product.FindAsync(id);// truy vấn một bản ghi dựa trên khóa chính.
            if (product == null) return NotFound();
            return product;
        }

        // POST: api/Products
        [HttpPost]// CREATE
        public async Task<ActionResult<Product>> PostProduct(Product product)//Tạo sản phẩm mớimới
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")] //UPDATE
        public async Task<IActionResult> PutProduct(int id, Product product)//Chỉnh sửa thông tin sản phẩm
        {
            if (id != product.Id) return BadRequest();

            _context.Entry(product).State = EntityState.Modified;//đánh dấu là cần cập nhật dữ liệu.
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")] // DELETE
        public async Task<IActionResult> DeleteProduct(int id)//Xóa sản phẩmphẩm
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return NotFound();

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}