using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSNB.ViewModels
{
    public class MemberViewModel
    {
        //[Required]
        public int MemberId { get; set; }

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

    public class CreateOrEditMemberViewModel
    {
        //[Required]
        public int MemberId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Display(Name = "Sur Name")]
        [MaxLength(100)]
        public string SurName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        [Required(ErrorMessage = "Date Of Birth is required.")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Address")]
        [MaxLength(200)]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [Display(Name = "Mobile Number")]
        [MaxLength(50)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User Enail is required.")]
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Alternative Email is required.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Alternative Email address")]
        public string Email { get; set; }

        [DisplayName("Profile Image")]
        [Required(ErrorMessage = "Image is required.")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Profile Thumb Image")]
        public string ThumbImageUrl { get; set; }

        [Display(Name = "Profile Small Image")]
        public string SmallImageUrl { get; set; }

        public UserViewModel UserViewModel { get; set; }

        public int MemberBloodGroupId { get; set; }
        public string MemberBloodGroupName { get; set; }
        public virtual MemberBloodGroupViewModel MemberBloodGroupViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberBloodGroups { get; set; }

        public int MemberDistrictId { get; set; }
        public string MemberDistrictName { get; set; }
        public virtual MemberDistrictViewModel MemberDistrictViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberDistricts { get; set; }

        public int MemberZoneId { get; set; }
        public string MemberZoneName { get; set; }
        public virtual MemberZoneViewModel MemberZoneViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberZones { get; set; }

        public int MemberHospitalId { get; set; }
        public string MemberHospitalName { get; set; }
        public virtual MemberHospitalViewModel MemberHospitalViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberHospitals { get; set; }

    }

    public class ResigterMemberViewModel
    {
        //[Required]
        public int MemberId { get; set; }

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

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Profile Thumb Image")]
        public string ThumbImageUrl { get; set; }

        [Display(Name = "Profile Small Image")]
        public string SmallImageUrl { get; set; }

        public UserViewModel UserViewModel { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please select one blood group.")]
        public int MemberBloodGroupId { get; set; }
        public string MemberBloodGroupName { get; set; }
        public virtual MemberBloodGroupViewModel MemberBloodGroupViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberBloodGroups { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please select one district.")]
        public int MemberDistrictId { get; set; }
        public string MemberDistrictName { get; set; }
        public virtual MemberDistrictViewModel MemberDistrictViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberDistricts { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please select one zone.")]
        public int MemberZoneId { get; set; }
        public string MemberZoneName { get; set; }
        public virtual MemberZoneViewModel MemberZoneViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberZoneGroups { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please select one hospital.")]
        public int MemberHospitalId { get; set; }
        public string MemberHospitalName { get; set; }
        public virtual MemberHospitalViewModel MemberHospitalViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberHospitalGroups { get; set; }
    }
}