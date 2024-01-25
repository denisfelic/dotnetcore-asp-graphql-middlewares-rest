using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_asp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_asp.Core.Database
{
    public class MyAppDbContext : DbContext
    {

        public DbSet<Todo> Todos { get; set; }

        public string DbPath { get; }

        public MyAppDbContext()
        {

            // var path = "/";
            DbPath = "todosdb.db"; //System.IO.Path.Join(path, "todosdb.db");
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}