using Microsoft.EntityFrameworkCore;
using PharmaCare.Models;

namespace PharmaCare.Data
{
    public class PharmacyContext :DbContext
    {

        public PharmacyContext(DbContextOptions<PharmacyContext>options) : base(options)
        {
            
        }

        public DbSet<Drug>Drugs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drug>().HasData(


                new Drug {Id=1, DrugName = "Acetaminophen" , DateCreated = DateTime.Now ,
                    ExpiryDate = new DateTime(2084, 11, 29) , price=421f , ImageUrl =""

                },
                 new Drug
                 {
                     Id = 2,
                     DrugName = "Doxycycline",
                     DateCreated = DateTime.Now,
                     ExpiryDate = new DateTime(2025, 9, 13),
                     price = 321f,
                     ImageUrl = ""

                 },
                  new Drug
                  {

                      Id = 3,
                      DrugName = "Lexapro",
                      DateCreated = DateTime.Now,
                      ExpiryDate = new DateTime(2025, 1, 12),
                      price = 401f,
                      ImageUrl = ""

                  },
                   new Drug
                   {

                       Id = 4,
                       DrugName = "Pantoprazole",
                       DateCreated = DateTime.Now,
                       ExpiryDate = new DateTime(2031, 11, 21),
                       price = 921f,
                       ImageUrl = ""

                   },
                    new Drug
                    {

                        Id = 5,
                        DrugName = "secukinumab",
                        DateCreated = DateTime.Now,
                        ExpiryDate = new DateTime(2027, 9, 28),
                        price = 1123f,
                        ImageUrl = ""

                    },
                     new Drug
                     {

                         Id = 6,
                         DrugName = "Wegovy",
                         DateCreated = DateTime.Now,
                         ExpiryDate = new DateTime(2052, 10, 29),
                         price = 891f,
                         ImageUrl = ""

                     }


                );
            
            
        }

    }
}
