using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaNivelacion.Models;

namespace PruebaNivelacion.Controllers
{
    [Route("books")]
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


        [Route("create")]
        public IActionResult Create(BookModel newBook)
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
                _context.Books.Add(insertion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View();
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
