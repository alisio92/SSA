using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal RentPrice { get; set; }
        public int Stock { get; set; }
        public string Picture { get; set; }
        public List<DeviceOperatingSystem> Os { get; set; }
        public List<ProgrammingFramework> Framework { get; set; }
        [NotMapped]
        public string Description { get; set; }
    }
}