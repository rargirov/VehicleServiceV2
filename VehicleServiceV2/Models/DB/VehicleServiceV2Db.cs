using Blueprints.DbModels;
using DbRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VehicleServiceV2.Models.DB
{
    public class VehicleServiceVDb2 : DbContext, IVehicleServiceDb
    {                    
        public VehicleServiceVDb2(DbContextOptions options) : base(options)
            //: base("name=DefaultConnection")
        {
        }

        //public DbSet<Customer> Customers { get; set; }

        public DbSet<Color> Colors { get; set; }

        //public DbSet<City> Cities { get; set; }

        //public DbSet<Country> Countries { get; set; }

        //public DbSet<CustomerVehicle> CustomerVehicles { get; set; }

        //public DbSet<Vehicle> Vehicles { get; set; }

        //public DbSet<VehicleManufacturer> VehicleManufacturers { get; set; }

        //public DbSet<ReplacementPartManufacturer> ReplacementPartManufacturers { get; set; }

        //public DbSet<ReplacementPart> ReplacementParts { get; set; }

        //public DbSet<ReplacementPartCategory> ReplacementPartCategories { get; set; }
        
        //public DbSet<VehicleType> VehicleTypes { get; set; }

        //public DbSet<RepairType> RepairTypes { get; set; }

        //public DbSet<Repair> Repairs { get; set; }

        //public DbSet<Person> People { get; set; }

        //public DbSet<Employee> Employees { get; set; }

        //public DbSet<UserProfile> UserProfiles { get; set; }

        //public DbSet<Order> Orders { get; set; }


        public IQueryable<T> Entities<T>() where T : class
        {
            return this.Set<T>().AsQueryable();
        }

        public void Add<T>(T entity) where T : class
        {
            this.Set<T>().Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            this.Set<T>().Remove(entity);
        }

        public void Update<T>(T entity, params string[] propertiesToUpdate) where T : class
        {
            var model = this.Entry(entity);

            if (propertiesToUpdate.Any())
            {
                this.Set<T>().Attach(entity);
                foreach (var propertyName in propertiesToUpdate)
                {
                    model.Property(propertyName).IsModified = true;
                }
            }
            else
            {
                model.State = EntityState.Modified;
            }
        }

        public int Save()
        {
            return this.SaveChanges();
        }
    }
}
