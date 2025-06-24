using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ClincDbContext : DbContext
    {
        public ClincDbContext(DbContextOptions<ClincDbContext> options)
            : base(options)
        {
        }

        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
        public DbSet<DoctorJoinRequest> DoctorJoinRequests { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // اجعل جميع الخصائص النصية تدعم اللغة العربية
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var stringProps = entity.ClrType
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(string));

                foreach (var prop in stringProps)
                {
                    modelBuilder.Entity(entity.Name)
                                .Property(prop.Name)
                                .IsUnicode(true);
                }
            }
            modelBuilder.Entity<DoctorSpecialty>()
                .HasKey(ds => new { ds.DoctorJoinRequestId, ds.MedicalSpecialtyId });

            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne(ds => ds.DoctorJoinRequest)
                .WithMany(d => d.DoctorSpecialties)
                .HasForeignKey(ds => ds.DoctorJoinRequestId);

            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne(ds => ds.MedicalSpecialty)
                .WithMany(ms => ms.DoctorSpecialties)
                .HasForeignKey(ds => ds.MedicalSpecialtyId);

            // Seed MedicalSpecialties
            modelBuilder.Entity<MedicalSpecialty>().HasData(
                new MedicalSpecialty
                {
                    Id = 1,
                    Name = "التغذية العلاجية",
                    IconClass = "🥗",
                    Description = "خطط غذائية متخصصة وعلاج اضطرابات التغذية",
                    Price = 30,
                    IsVisibleToPatient = true
                },
                new MedicalSpecialty
                {
                    Id = 2,
                    Name = "الجراحة العامة",
                    IconClass = "⚕️",
                    Description = "استشارات جراحية متقدمة وتقييم الحالات",
                    Price = 50,
                    IsVisibleToPatient = true
                },
                new MedicalSpecialty
                {
                    Id = 3,
                    Name = "الطب النفسي",
                    IconClass = "🧠",
                    Description = "علاج الاضطرابات النفسية والدعم النفسي",
                    Price = 40,
                    IsVisibleToPatient = true
                },
                new MedicalSpecialty
                {
                    Id = 4,
                    Name = "أمراض القلب",
                    IconClass = "❤️",
                    IsVisibleToPatient = false
                },
                new MedicalSpecialty
                {
                    Id = 5,
                    Name = "الأمراض الجلدية",
                    IconClass = "🩺",
                    IsVisibleToPatient = false
                },
                new MedicalSpecialty
                {
                    Id = 6,
                    Name = "طب الأطفال",
                    IconClass = "👶",
                    IsVisibleToPatient = false
                },
                new MedicalSpecialty
                {
                    Id = 7,
                    Name = "العظام",
                    IconClass = "🦴",
                    IsVisibleToPatient = false
                },
                new MedicalSpecialty
                {
                    Id = 8,
                    Name = "الأعصاب",
                    IconClass = "🧠",
                    IsVisibleToPatient = false
                },
                new MedicalSpecialty
                {
                    Id = 9,
                    Name = "تخصص آخر",
                    IconClass = "🏥",
                    IsVisibleToPatient = false
                }
            );
        }
    }
}
