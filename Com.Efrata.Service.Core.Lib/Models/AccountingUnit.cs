﻿using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.Efrata.Service.Core.Lib.Models
{
    public class AccountingUnit : StandardEntity, IValidatableObject
    {
        [StringLength(100)]
        public string Code { get; set; }

        public int DivisionId { get; set; }

        [StringLength(100)]
        public string DivisionCode { get; set; }

        [StringLength(500)]
        public string DivisionName { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public string Description { get; set; }
        public int BudgetCashflowLayoutOrder { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Code))
                validationResult.Add(new ValidationResult("Code is required", new List<string> { "code" }));

            if (string.IsNullOrWhiteSpace(this.Name))
                validationResult.Add(new ValidationResult("Name is required", new List<string> { "name" }));

            return validationResult;
        }
    }
}
