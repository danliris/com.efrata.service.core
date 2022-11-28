﻿using Com.Moonlay.Models;
using System.ComponentModel.DataAnnotations;

namespace Com.Efrata.Service.Core.Lib.Models
{
    public class GarmentAdditionalChargesModel : StandardEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
