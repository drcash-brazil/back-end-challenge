using DrcashTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrcashTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet <Book> Books  { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }


            /*
             * https://www.youtube.com/watch?v=ipbSwv09dDU
             * get-help entityframeworkcore
             * Add-Migration initial
             * Remove-migration
             * update-database
             * script-migration
             */
       
    }
}