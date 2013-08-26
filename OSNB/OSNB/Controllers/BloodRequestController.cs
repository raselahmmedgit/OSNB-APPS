using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSNB.Models;
using OSNB.ViewModels;
using OSNB.Helpers;

namespace OSNB.Controllers
{
    public class BloodRequestController : Controller
    {
        private AppDbContext _db = new AppDbContext();
        //
        // GET: /BloodRequest/

        public ActionResult Index()
        {
            return View();
        }

        //ForBlood
        public ActionResult ForBlood()
        {
            try
            {

                var memberBloodGroups = SelectListItemExtension.PopulateDropdownList(_db.MemberBloodGroups.ToList<MemberBloodGroup>(), "Id", "BloodGroupName").ToList();


                var bloodRequestViewModel = new BloodRequestViewModel { ddlMemberBloodGroups = memberBloodGroups };

                return View(bloodRequestViewModel);



            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return RedirectToAction("Index", "BloodRequest");
            }

        }

        [HttpPost]
        public ActionResult ForBlood(BloodRequestViewModel viewModel)
        {

            var memberBloodGroups = SelectListItemExtension.PopulateDropdownList(_db.MemberBloodGroups.ToList<MemberBloodGroup>(), "Id", "BloodGroupName", isEdit: true, selectedValue: viewModel.RequiredBloodGroupId != 0 ? viewModel.RequiredBloodGroupId.ToString() : "0").ToList();


            viewModel.ddlMemberBloodGroups = memberBloodGroups;


            try
            {
                if (ModelState.IsValid)
                {

                    BloodRequest model = new BloodRequest { RequesterName = viewModel.RequesterName, RequesterContactNo = viewModel.RequesterContactNo, RequesterAmount = viewModel.RequesterAmount, PresentLocation = viewModel.PresentLocation, DateOfDonation = Convert.ToDateTime(viewModel.DateOfDonation), AppealMessage = viewModel.AppealMessage, RequiredBloodGroupId = viewModel.RequiredBloodGroupId };

                    _db.BloodRequests.Add(model);
                    _db.SaveChanges();

                    return RedirectToAction("Index", "BloodRequest");
                }

                //return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return View(viewModel);
            }

        }

    }
}
