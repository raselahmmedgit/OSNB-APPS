﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OSNB.ViewModels
{
    public class MemberDistrictViewModel
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "District Name")]
        [MaxLength(100)]
        public string DistrictName { get; set; }
    }
}