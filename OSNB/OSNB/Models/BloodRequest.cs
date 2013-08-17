﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OSNB.Models
{
    public class BloodRequest
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Your Name")]
        [MaxLength(200)]
        public string RequesterName { get; set; }

        [Display(Name = "Your Contact No")]
        [MaxLength(100)]
        public string RequesterContactNo { get; set; }

        [Display(Name = "Amount(Unit/Bag)")]
        [MaxLength(100)]
        public string RequesterAmount { get; set; }

        [Display(Name = "Patient's Present Location")]
        [MaxLength(250)]
        public string PresentLocation { get; set; }

        [Display(Name = "Date of Donation")]
        public DateTime DateOfDonation { get; set; }

        [Display(Name = "More Message")]
        [MaxLength(250)]
        public string AppealMessage { get; set; }

        //Required Blood Group
        public int RequiredBloodGroupId { get; set; }
        [ForeignKey("RequiredBloodGroupId")]
        public virtual MemberBloodGroup MemberBloodGroup { get; set; }

    }
}