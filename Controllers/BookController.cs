using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaNivelacion.Models;

namespace PruebaNivelacion.Controllers
{
    public class BookController : Controller
    {
        private BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }
        public ActionResult Books()
        {
            var books = _context.Books.Take(5).ToList();

            return View(books);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookModel newBook)
        {
            string name = newBook.Nombre_libro;
            string author = newBook.Autor;
            DateTime releaseDate = newBook.Fecha_lanzamiento;
            string user = "stan";

            var insertion = new BookModel
            {

                Nombre_libro = name,
                Autor = author,
                Fecha_lanzamiento = releaseDate,
                Campos_auditoria = user
            };

            try
            {
                await _context.Books.AddAsync(insertion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }

        [Route("update")]
        public ActionResult Update()
        {
            return View();
        }

        [Route("delete")]
        public ActionResult Delete()
        {
            return View();
        }

    }
}
