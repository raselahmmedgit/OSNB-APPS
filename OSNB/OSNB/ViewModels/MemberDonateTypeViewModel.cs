﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OSNB.ViewModels
{
    public class MemberDonateTypeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Donate Type Name")]
        [MaxLength(200)]
        public string DonateTypeName { get; set; }
    }
}