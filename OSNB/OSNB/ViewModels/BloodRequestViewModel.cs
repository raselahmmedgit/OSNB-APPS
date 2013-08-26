using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSNB.ViewModels
{
    public class BloodRequestViewModel
    {
        [Required]
        public int BloodRequestId { get; set; }

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
        public DateTime? DateOfDonation { get; set; }

        [Display(Name = "More Message")]
        [MaxLength(250)]
        public string AppealMessage { get; set; }

        //Required Blood Group
        public int RequiredBloodGroupId { get; set; }
        public string RequiredBloodGroupName { get; set; }
        public virtual MemberBloodGroupViewModel MemberBloodGroupViewModel { get; set; }

        public IEnumerable<SelectListItem> ddlMemberBloodGroups { get; set; }
    }
}