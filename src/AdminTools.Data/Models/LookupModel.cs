using System;
using System.ComponentModel.DataAnnotations;

namespace AdminTools.Data.Models
{


    public class BusinessLookup : LookupTable
    {
        public string BusinessUnit { get; set; }
    }

    public class LocationLookup : LookupTable
    {
        public int MyProperty { get; set; }
    }

    public class ModelLookup : LookupTable
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }

    public class OSLookup : LookupTable
    {
        public string Family { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public class LookupTable
    {
        [Key]
        public int Id { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}
