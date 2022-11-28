﻿using Com.Efrata.Service.Core.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Efrata.Service.Core.Lib.ViewModels
{
    public class VatViewModel : BasicViewModel
    {
        public string Name { get; set; }

        public double? Rate { get; set; }

        public string Description { get; set; }

        public string COACodeCredit { get; set; }

        public DateTimeOffset? Date { get; set; }
    }
}
