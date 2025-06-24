using DAL.Data.Models;
using DAL.Data.Repositories.DoctorRequest;
using DAL.Data.Repositories.MedicalRepo;
using Microsoft.AspNetCore.Mvc;

namespace MyClinc.Controllers
{
    public class DoctorJoinRequestsController(IDoctorJoinRequestRepo _doctorRepo,
            IMedicalSpecialtyRepository _specialtyRepo) : Controller
    {
        public async Task<IActionResult> Create()
        {
            ViewBag.Specialties = await _specialtyRepo.GetAllAsync();
            return View();
        }

        //POST: /DoctorJoinRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorJoinRequest model, int[] SelectedSpecialties)
        {
            if (ModelState.IsValid)
            {
                model.DoctorSpecialties = SelectedSpecialties.Select(id => new DoctorSpecialty
                {
                    MedicalSpecialtyId = id
                }).ToList();

                await _doctorRepo.AddAsync(model);
                await _doctorRepo.SaveAsync();

                return RedirectToAction("ThankYou");
            }

            ViewBag.Specialties = await _specialtyRepo.GetAllAsync();
            return View(model);
        }

        // GET: /DoctorJoinRequests
        // Admin
        public async Task<IActionResult> Index()
        {
            var data = await _doctorRepo.GetAllAsync();
            return View(data);
        }

        //GET: /DoctorJoinRequests/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor == null)
                return NotFound();

            return View(doctor);
        }

        //GET: /DoctorJoinRequests/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor == null)
                return NotFound();

            return View(doctor);
        }
        //POST: /DoctorJoinRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor != null)
            {
                _doctorRepo.Delete(doctor);
                await _doctorRepo.SaveAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
