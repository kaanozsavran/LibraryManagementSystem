using System.Threading.Tasks;
using libraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace libraryManagementSystem.Controllers {

    public class BookController : Controller{
         
        private readonly DataContext _context;
        public BookController(DataContext context){
            _context = context;
        }

   


        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
         public async Task<IActionResult> Create(Book model){
            _context.Books.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}