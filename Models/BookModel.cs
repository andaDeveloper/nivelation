using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PruebaNivelacion.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }
        public DbSet<BookModel> Books { get; set; }

    }

    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_libro { get; set; }
        public string Nombre_libro { get; set; }
        public string Autor { get; set; }

        //Pending to check how it makes the conversion from input
        public DateTime Fecha_lanzamiento { get; set; }
        public string Campos_auditoria { get; set; }
    }

}


