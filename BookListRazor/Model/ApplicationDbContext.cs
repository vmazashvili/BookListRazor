using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // <-- Add This to inherit from DbContext


namespace BookListRazor.Model
{
    public class ApplicationDbContext : DbContext // <-- inherited class from Microsoft.EntityFrameworkCore
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
    }
}
