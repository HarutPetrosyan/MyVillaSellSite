using MagicVilla_VillaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaApi.Data
{
    public class AplicationDBContext:DbContext
    {
        public  AplicationDBContext(DbContextOptions<AplicationDBContext> options ):base(options)
        {
        }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "chgitem inch chgitem vonc",
                    ImageUrl =
                        "https://gallery.streamlinevrs.com/units-gallery/00/06/4C/image_162708236.jpeg",
                    Occupancy = 4,
                    Sqft = 250,
                    Rate = 200,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Pink Villa",
                    Details = "chgitem inch chgitem vonc",
                    ImageUrl = "https://cache.desktopnexus.com/thumbseg/456/456996-bigthumbnail.jpg",
                    Occupancy = 10,
                    Sqft = 300,
                    Rate = 100,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Black Villa",
                    Details = "chgitem inch chgitem vonc",
                    ImageUrl =
                        "https://www.amazingarchitecture.com/photos/5/Reza%20Mohatashami/Black%20Villa/Black-Villa-Reza-Mohtashami-New-York-USA-001.jpg",
                    Occupancy = 6,
                    Sqft = 300,
                    Rate = 200,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Minimalistic Villa",
                    Details = "chgitem inch chgitem vonc",
                    ImageUrl = "https://vwartclub.com/media/projects/4198/1.jpg",
                    Occupancy = 7,
                    Sqft = 500,
                    Rate = 200,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Italiano Villa",
                    Details = "chgitem inch chgitem vonc",
                    ImageUrl =
                        "https://www.luxury-architecture.net/wp-content/uploads/2018/04/1522725431-6222-16x9-0-51-848.20170803170501.jpg",
                    Occupancy = 28,
                    Sqft = 3700,
                    Rate = 400,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                });
        }
    }
}
