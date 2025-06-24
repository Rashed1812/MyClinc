using DAL.Data.Models;
using DAL.Data.Repositories.MedicalRepo;
using Microsoft.AspNetCore.Mvc;

namespace MyClinc.Controllers
{
    public class MedicalSpecialtyController(IMedicalSpecialtyRepository _medicalSpecialtyRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var specialties = await _medicalSpecialtyRepository.GetAllAsync();
            return View(specialties);
        }

        // GET: MedicalSpecialty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalSpecialty/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalSpecialty specialty)
        {
            if (ModelState.IsValid)
            {
                await _medicalSpecialtyRepository.AddAsync(specialty);
                return RedirectToAction(nameof(Index));
            }
            return View(specialty);
        }

        // GET: MedicalSpecialty/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var specialty = await _medicalSpecialtyRepository.GetByIdAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        // POST: MedicalSpecialty/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MedicalSpecialty specialty)
        {
            if (id != specialty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 _medicalSpecialtyRepository.Update(specialty);
                return RedirectToAction(nameof(Index));
            }
            return View(specialty);
        }

        // GET: MedicalSpecialty/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var specialty = await _medicalSpecialtyRepository.GetByIdAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        // POST: MedicalSpecialty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             _medicalSpecialtyRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
