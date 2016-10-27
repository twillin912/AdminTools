using System;

namespace AdminTools.Data
{
    public static class DataContextSeedData
    {
        public static void Seed(DataContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.SaveChanges();
        }

    }
}
