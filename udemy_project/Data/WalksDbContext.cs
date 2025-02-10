﻿using Microsoft.EntityFrameworkCore;
using udemy_project.Models.Domain;

namespace udemy_project.Data
{
    public class WalksDbContext: DbContext
    {
        public WalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
