﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MyLeasing.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Models
{
    public class PropertyViewModel : Property
    {
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Property Type")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a property type.")]
        public int PropertyTypeId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Business Type")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a business type.")]
        public int BusinessTypeId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Agent")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a agent.")]
        public int AgentId { get; set; }

        public IEnumerable<SelectListItem> PropertyTypes { get; set; }
        public IEnumerable<SelectListItem> BusinessTypes { get; set; }

        public IEnumerable<SelectListItem> Agents { get; set; }
    }
}
