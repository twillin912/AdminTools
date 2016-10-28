using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AdminTools.Data.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string AssetTag { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public ModelLookup Model { get; set; }
        public BusinessLookup BuinessUnit { get; set; }
        public LocationLookup Location { get; set; }
        public string Application { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? DeployDate { get; set; }
        public DateTime? ServiceExpiration { get; set; }
        public int? TotalCores { get; set; }
        public int? Memory { get; set; }
        public OSLookup OperatingSystem { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

    public class AssetHistory : Asset
    {
        public int AssetId { get; set; }
    }
}
