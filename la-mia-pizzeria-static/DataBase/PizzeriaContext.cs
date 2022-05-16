﻿using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;


namespace la_mia_pizzeria_static.Data
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Pizza> Pizza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=pizzeria_pizze;Integrated Security=True");
        }
    }
}
