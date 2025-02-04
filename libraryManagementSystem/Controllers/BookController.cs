using System.Linq.Expressions;
using System.Threading.Tasks;
using libraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryManagementSystem.Controllers {

    public class BookController : Controller{
         
        private readonly DataContext _context;
        public BookController(DataContext context){
            _context = context;
        }

    public async Task<IActionResult> Index(){
        return View(await _context.Books.ToListAsync());
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


        public async Task<IActionResult> Edit(int? id){
                if(id==null){
                    return NotFound();
                }
                var book = await _context.Books.FindAsync(id);

                if(book==null){
                    return NotFound();
                }
                return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken] // farklı token'ların aynı veriye işlem yapmalarını engeller.
        public async Task<IActionResult> Edit(int id, Book model){
                if(id!= model.BookID){
                    return NotFound();
                }

                if(ModelState.IsValid){
                    try
                    {
                        _context.Update(model);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException) //birden fazla kullanıcı aynı anda güncelleme işlemi yapamaması için.
                    {
                        if(!_context.Books.Any(o=>o.BookID == model.BookID)){
                            return NotFound();
                        }
                        else{
                            throw;
                        }
                    }
                    return RedirectToAction("Index");
                }
                return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
             var book = _context.Books.Find(id);
         if (book == null)
        {
             return NotFound();
        }

         _context.Books.Remove(book);
         _context.SaveChanges();

        TempData["SuccessMessage"] = "Kitap başarıyla silindi!";
        return RedirectToAction("Index");
        }
    }
}