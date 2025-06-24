using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Repositories.MedicalRepo
{
    public class MedicalSpecialtyRepository(ClincDbContext _dbContext) : IMedicalSpecialtyRepository
    {
        public async Task<IEnumerable<MedicalSpecialty>> GetAllAsync()
        {
            return await _dbContext.MedicalSpecialties.ToListAsync();
        }

        public async Task<MedicalSpecialty?> GetByIdAsync(int id)
        {
            return await _dbContext.MedicalSpecialties.FindAsync(id);
        }

        public async Task AddAsync(MedicalSpecialty entity)
        {
            await _dbContext.MedicalSpecialties.AddAsync(entity);
        }

        public void Update(MedicalSpecialty entity)
        {
            _dbContext.MedicalSpecialties.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.MedicalSpecialties.FindAsync(id);
            if (entity != null)
            {
                _dbContext.MedicalSpecialties.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
