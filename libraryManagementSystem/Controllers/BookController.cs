using Microsoft.AspNetCore.Mvc;

namespace libraryManagementSystem.Controllers {

    public class BookController : Controller{
         

        public IActionResult Create(){
            return View();
        }

    }
}