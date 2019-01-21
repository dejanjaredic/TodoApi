using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TodoApi.Models;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base (options)
        {

        }
       

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Zadatak> Zadataks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var jsonString = File.ReadAllText("users2.json");
            var list = JsonConvert.DeserializeObject<List<Zadatak>>(jsonString);
            modelBuilder.Entity<Zadatak>().HasData(list);
        }
    }
}
