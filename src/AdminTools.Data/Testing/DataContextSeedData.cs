using AdminTools.Data.Models;
using System;
using System.Linq;

namespace AdminTools.Data
{
    public static class DataContextSeedData
    {
        public static void Seed(DataContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.BusinessUnits.Any())
            {
                AddBusinessUnits(context);
            }

            if (!context.Locations.Any())
            {
                AddLocations(context);
            }

            if (!context.Models.Any())
            {
                AddModels(context);
            }

            if (!context.Assets.Any())
            {
                AddAssets(context);
            }

            context.SaveChanges();
        }

        private static void AddBusinessUnits(DataContext context)
        {
            context.AddRange(
                new BusinessLookup { BusinessUnit = "Cambium Learning" },
                new BusinessLookup { BusinessUnit = "ExploreLearning" },
                new BusinessLookup { BusinessUnit = "Learning A-Z" },
                new BusinessLookup { BusinessUnit = "Kurzweil Education" },
                new BusinessLookup { BusinessUnit = "Voyager Sopris Learning" }
                );
        }

        private static void AddLocations(DataContext context)
        {

        }

        private static void AddModels(DataContext context)
        {

        }

        private static void AddAssets(DataContext context)
        {
            context.AddRange(
                new Asset { AssetTag = "CLG00001", Name = "Server01", SerialNumber = "ABCXYZ1" },
                new Asset { AssetTag = "CLG00002", Name = "Server02", SerialNumber = "ABCXYZ2" },
                new Asset { AssetTag = "CLG00003", Name = "Server03", SerialNumber = "ABCXYZ3" },
                new Asset { AssetTag = "CLG00004", Name = "PDU01", SerialNumber = "ABCXYZ4" },
                new Asset { AssetTag = "CLG00005", Name = "PDU02", SerialNumber = "ABCXYZ5" }
                );
        }
    }
}
