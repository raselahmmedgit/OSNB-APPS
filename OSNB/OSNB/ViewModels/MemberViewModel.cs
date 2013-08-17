using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OSNB.ViewModels
{
    public class MemberViewModel
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Display(Name = "Sur Name")]
        [MaxLength(100)]
        public string SurName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Address")]
        [MaxLength(200)]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Mobile Number")]
        [MaxLength(50)]
        public string MobileNumber { get; set; }

        [Display(Name = "Profile Thumb Image")]
        public string ThumbImageUrl { get; set; }

        [Display(Name = "Profile Small Image")]
        public string SmallImageUrl { get; set; }

        //one to one relationship with user
        public string UserName { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public int MemberBloodGroupId { get; set; }
        public string MemberBloodGroupName { get; set; }
        public virtual MemberBloodGroupViewModel MemberBloodGroupViewModel { get; set; }

        public int MemberDistrictId { get; set; }
        public string MemberDistrictName { get; set; }
        public virtual MemberDistrictViewModel MemberDistrictViewModel { get; set; }

        public int MemberZoneId { get; set; }
        public string MemberZoneName { get; set; }
        public virtual MemberZoneViewModel MemberZoneViewModel { get; set; }

        public int MemberHospitalId { get; set; }
        public string MemberHospitalName { get; set; }
        public virtual MemberHospitalViewModel MemberHospitalViewModel { get; set; }

        public virtual ICollection<MemberDonateViewModel> MemberDonateViewModels { get; set; }

        public virtual ICollection<MemberStatusViewModel> MemberStatusViewModels { get; set; }
    }
}