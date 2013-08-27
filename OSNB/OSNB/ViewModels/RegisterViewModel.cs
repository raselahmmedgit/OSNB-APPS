using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OSNB.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

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

        [Display(Name = "Contact No")]
        [MaxLength(200)]
        public string ContactNo { get; set; }

        public int MemberBloodGroupId { get; set; }
        public string MemberBloodGroupName { get; set; }
        public virtual MemberBloodGroupViewModel MemberBloodGroupViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberBloodGroups { get; set; }

        public int MemberDistrictId { get; set; }
        public string MemberDistrictName { get; set; }
        public virtual MemberDistrictViewModel MemberDistrictViewModel { get; set; }
        public IEnumerable<SelectListItem> ddlMemberDistricts { get; set; }
    }
}