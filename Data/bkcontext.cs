using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bookkeepingAPI.Models;

    public class bkcontext : DbContext
    {
        public bkcontext (DbContextOptions<bkcontext> options)
            : base(options)
        {
        }

        public DbSet<bookkeepingAPI.Models.TodoItems> TodoItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./bkDB.db");
        }
        public DbSet<bookkeepingAPI.Models.Contacts> Contacts { get; set; }
        public DbSet<bookkeepingAPI.Models.Cashbook> Cashbook { get; set; }
    }
