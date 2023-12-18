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
            var booksViewModel = books.Select(book => new BookModel
            {
                Nombre_libro = book.Nombre_libro,
                Autor = book.Autor,
                Fecha_lanzamiento = book.Fecha_lanzamiento,
                Campos_auditoria = book.Campos_auditoria,
            }).ToList();

            return View("Books", booksViewModel);
        }


        [Route("create")]
        public ActionResult Create()
        {
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
