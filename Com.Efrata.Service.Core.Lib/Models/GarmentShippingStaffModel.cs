﻿using Com.Moonlay.Models;
using System.ComponentModel.DataAnnotations;

namespace Com.Efrata.Service.Core.Lib.Models
{
    public class GarmentShippingStaffModel : StandardEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
