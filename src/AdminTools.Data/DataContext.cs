﻿using Microsoft.EntityFrameworkCore;

namespace AdminTools.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }

}
