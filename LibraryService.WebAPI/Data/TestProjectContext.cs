using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Data
{
    public class TestProjectContext : DbContext
    {
        public TestProjectContext(DbContextOptions<TestProjectContext> options)
            : base(options)
        { }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
    }

    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }

        public static implicit operator Book(Task<Book> v)
        {
            throw new NotImplementedException();
        }
    }

    public class Library
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
