using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookProgram.Model;

namespace BookProgram.Data
{
    public class BookProgramContext : DbContext
    {
        public BookProgramContext(DbContextOptions<BookProgramContext> options)
            : base(options)
        {
        }

        public DbSet<BookProgram.Model.BookList> BookList { get; set; } = default!;

        public DbSet<BookProgram.Model.Hold> Hold { get; set; }

        public DbSet<BookProgram.Model.Orders> Orders { get; set; }

        
    }
}
