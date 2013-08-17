using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSNB.Helpers;
using OSNB.Models;
using OSNB.ViewModels;
using OSNB.ViewModels.DataTableViewModels;

namespace OSNB.Areas.Admin.Controllers
{
    public class MemberController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /Admin/Member/

        public ActionResult Index()
        {
            return View();
        }

        // for display datatable
        public ActionResult GetMembers(DataTableParamModel param)
        {
            var members = _db.Members.ToList();

            var viewMembers = members.Select(m => new MemberTableModel() { MemberId = Convert.ToString(m.Id), FullName = m.FullName, Address = m.Address, DateOfBirth = Convert.ToString(m.DateOfBirth), PhoneNumber = m.PhoneNumber, MobileNumber = m.MobileNumber, UserName = m.UserName, });

            IEnumerable<MemberTableModel> filteredMembers;

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredMembers = viewMembers.Where(m => (m.FullName ?? "").Contains(param.sSearch)).ToList();
            }
            else
            {
                filteredMembers = viewMembers;
            }

            var viewOdjects = filteredMembers.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from pMdl in viewOdjects
                         select new[] { pMdl.FullName, pMdl.Address, pMdl.DateOfBirth, pMdl.PhoneNumber, pMdl.MobileNumber, pMdl.UserName, pMdl.MemberId };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = members.Count(),
                iTotalDisplayRecords = filteredMembers.Count(),
                aaData = result
            },
                            JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Member/Details/By ID

        public ActionResult Details(int id)
        {
            try
            {
                var member = _db.Members.Find(id);
                if (member != null)
                {
                    var memberViewModel = new MemberViewModel { Id = member.Id, FirstName = member.FirstName, LastName = member.LastName, SurName = member.SurName, DateOfBirth = member.DateOfBirth, Address = member.Address, PhoneNumber = member.PhoneNumber, MobileNumber = member.MobileNumber, ThumbImageUrl = member.ThumbImageUrl, SmallImageUrl = member.SmallImageUrl, MemberBloodGroupId = member.MemberBloodGroupId, MemberBloodGroupName = member.MemberBloodGroup != null ? member.MemberBloodGroup.BloodGroupName : null, MemberDistrictId = member.MemberDistrictId, MemberDistrictName = member.MemberDistrict != null ? member.MemberDistrict.DistrictName : null, MemberZoneId = member.MemberZoneId, MemberZoneName = member.MemberZone != null ? member.MemberZone.ZoneName : null, MemberHospitalId = member.MemberHospitalId, MemberHospitalName = member.MemberHospital != null ? member.MemberHospital.HospitalName : null, UserName = member.UserName };

                    return PartialView("_Details", memberViewModel);
                }
                else
                {
                    return RedirectToAction("Index", "Member");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return RedirectToAction("Index", "Member");
            }
        }

        //
        // GET: /Member/Add

        public ActionResult Add()
        {
            try
            {
                return PartialView("_Add");
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return RedirectToAction("Index", "Member");
            }
        }

        //
        // POST: /Member/Add

        [HttpPost]
        public ActionResult Add(MemberViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var member = new OSNB.Models.Member { Id = viewModel.Id, FirstName = viewModel.FirstName, LastName = viewModel.LastName, SurName = viewModel.SurName, DateOfBirth = viewModel.DateOfBirth, Address = viewModel.Address, PhoneNumber = viewModel.PhoneNumber, MobileNumber = viewModel.MobileNumber, ThumbImageUrl = viewModel.ThumbImageUrl, SmallImageUrl = viewModel.SmallImageUrl, MemberBloodGroupId = viewModel.MemberBloodGroupId, MemberDistrictId = viewModel.MemberDistrictId, MemberZoneId = viewModel.MemberZoneId, MemberHospitalId = viewModel.MemberHospitalId, UserName = viewModel.UserName };

                    _db.Members.Add(member);
                    _db.SaveChanges();

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return Content("Sorry! Unable to add this member.");
            }

        }

        //
        // GET: /Member/Edit/By ID

        public ActionResult Edit(int id)
        {
            try
            {
                var member = _db.Members.Find(id);
                if (member != null)
                {
                    var memberViewModel = new MemberViewModel { Id = member.Id, FirstName = member.FirstName, LastName = member.LastName, SurName = member.SurName, DateOfBirth = member.DateOfBirth, Address = member.Address, PhoneNumber = member.PhoneNumber, MobileNumber = member.MobileNumber, ThumbImageUrl = member.ThumbImageUrl, SmallImageUrl = member.SmallImageUrl, MemberBloodGroupId = member.MemberBloodGroupId, MemberBloodGroupName = member.MemberBloodGroup != null ? member.MemberBloodGroup.BloodGroupName : null, MemberDistrictId = member.MemberDistrictId, MemberDistrictName = member.MemberDistrict != null ? member.MemberDistrict.DistrictName : null, MemberZoneId = member.MemberZoneId, MemberZoneName = member.MemberZone != null ? member.MemberZone.ZoneName : null, MemberHospitalId = member.MemberHospitalId, MemberHospitalName = member.MemberHospital != null ? member.MemberHospital.HospitalName : null, UserName = member.UserName };

                    return PartialView("_Edit", memberViewModel);
                }
                else
                {
                    return RedirectToAction("Index", "Member");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return RedirectToAction("Index", "Member");
            }
        }

        //
        // POST: /Member/Edit/By ID

        [HttpPost]
        public ActionResult Edit(MemberViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var member = new OSNB.Models.Member { Id = viewModel.Id, FirstName = viewModel.FirstName, LastName = viewModel.LastName, SurName = viewModel.SurName, DateOfBirth = viewModel.DateOfBirth, Address = viewModel.Address, PhoneNumber = viewModel.PhoneNumber, MobileNumber = viewModel.MobileNumber, ThumbImageUrl = viewModel.ThumbImageUrl, SmallImageUrl = viewModel.SmallImageUrl, MemberBloodGroupId = viewModel.MemberBloodGroupId, MemberDistrictId = viewModel.MemberDistrictId, MemberZoneId = viewModel.MemberZoneId, MemberHospitalId = viewModel.MemberHospitalId, UserName = viewModel.UserName };

                    _db.Entry(member).State = EntityState.Modified;
                    _db.SaveChanges();

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return Content("Sorry! Unable to edit this member.");
            }
        }

        //
        // GET: /Member/Delete/By ID

        public ActionResult Delete(int id)
        {
            try
            {
                var member = _db.Members.Find(id);
                if (member != null)
                {
                    var memberViewModel = new MemberViewModel { Id = member.Id, FirstName = member.FirstName, LastName = member.LastName, SurName = member.SurName, DateOfBirth = member.DateOfBirth, Address = member.Address, PhoneNumber = member.PhoneNumber, MobileNumber = member.MobileNumber, ThumbImageUrl = member.ThumbImageUrl, SmallImageUrl = member.SmallImageUrl, MemberBloodGroupId = member.MemberBloodGroupId, MemberBloodGroupName = member.MemberBloodGroup != null ? member.MemberBloodGroup.BloodGroupName : null, MemberDistrictId = member.MemberDistrictId, MemberDistrictName = member.MemberDistrict != null ? member.MemberDistrict.DistrictName : null, MemberZoneId = member.MemberZoneId, MemberZoneName = member.MemberZone != null ? member.MemberZone.ZoneName : null, MemberHospitalId = member.MemberHospitalId, MemberHospitalName = member.MemberHospital != null ? member.MemberHospital.HospitalName : null, UserName = member.UserName };

                    return PartialView("_Delete", memberViewModel);
                }
                else
                {
                    return RedirectToAction("Index", "Member");
                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return RedirectToAction("Index", "Member");
            }
        }

        //
        // POST: /Member/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var member = _db.Members.Find(id);
                if (member != null)
                {
                    _db.Members.Remove(member);
                    _db.SaveChanges();

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionMessageFormat(ex, true);
                return Content("Sorry! Unable to delete this member.");
            }
        }

    }
}
