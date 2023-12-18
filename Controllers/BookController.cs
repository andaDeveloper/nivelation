using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> Books()
        {
            var books = await _context.Books.ToListAsync();

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

            //replace for user session
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
                return RedirectToAction("Books");
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
                var book = await _context.Books.FirstOrDefaultAsync(book => book.Id_libro == id); 

                if(book != null) 
                {
                    var injection = new BookModel
                    {

                        Id_libro = book.Id_libro, Nombre_libro = book.Nombre_libro,
                        Autor = book.Autor,
                        Fecha_lanzamiento = book.Fecha_lanzamiento,
                        Campos_auditoria = book.Campos_auditoria

                    };

                    return View(injection);
                }

            return RedirectToAction("Index");

        }

    }
}
