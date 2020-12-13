using Microsoft.EntityFrameworkCore;

namespace ProjectStep8.Models
{
   public class AppDbContext
      : DbContext
   {
      //   F i e l d s   &   P r o p e r t i e s

      public DbSet<Goal>  Goals  { get; set; }

      public DbSet<Hike>  Hikes  { get; set; }

      public DbSet<Peak>  Peaks  { get; set; }

      public DbSet<Trail> Trails { get; set; }

      public DbSet<User>  Users  { get; set; }

      //   C o n s t r u c t o r s

      public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
      {
      }

      //   M e t h o d s

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<User>()
                     .HasIndex(u => u.Email)
                     .IsUnique();

         //   P B a n t a 1 0 1   /   W o m b a t 1

         modelBuilder.Entity<User>().HasData
            (new User
            {
               Id = 1,
               Email = "PBanta101@GMail.Com",
               Password = "479ed019aea4c1769a39d5ed0e79b7ca943486e2d15b937b0ff1725b2aed09b3",
               IsAdmin = true
            });

         modelBuilder.Entity<User>().HasData
            (new User
            {
               Id = 2,
               Email = "PBanta101@Example.Com",
               Password = "479ed019aea4c1769a39d5ed0e79b7ca943486e2d15b937b0ff1725b2aed09b3",
               IsAdmin = false
            });

         //   P i k e s   P e a k

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 1,
               Name = "Pikes Peak",
               Elevation = 14110,
               County = "El Paso",
               NearestTown = "Colorado Springs"
            });

         modelBuilder.Entity<Trail>().HasData
            (new Trail
            {
               Id = 1,
               Name = "Barr Trail",
               StartingElevation = 6650,
               Distance = 12,
               PeakId = 1
            });

         modelBuilder.Entity<Trail>().HasData
            (new Trail
            {
               Id = 2,
               Name = "Crags",
               StartingElevation = 10000,
               Distance = 7,
               PeakId = 1
            });

         //   H a n d i e s   P e a k

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 2,
               Name = "Handies Peak",
               Elevation = 14048,
               County = "Hinsdale"
            });

         modelBuilder.Entity<Trail>().HasData
            (new Trail
            {
               Id = 3,
               Name = "Southwest",
               StartingElevation = 11600,
               Distance = 2.75f,
               PeakId = 2
            });

         modelBuilder.Entity<Trail>().HasData
            (new Trail
            {
               Id = 4,
               Name = "West",
               StartingElevation = 11300,
               Distance = 1.5f,
               PeakId = 2
            });

         //   G r a y s   P e a k

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 3,
               Name = "Grays Peak",
               Elevation = 14270
            });

         //   M t .   B i e r s t a d t

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 4,
               Name = "Mt. Bierstadt",
               Elevation = 14060,
               County = "Clear Creek"
            });

         //   Q u a n d r y   P e a k

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 5,
               Name = "Quandry Peak",
               Elevation = 14265,
               County = "Summit",
               NearestTown = "Breckenridge"
            });

         modelBuilder.Entity<Trail>().HasData
            (new Trail
            {
               Id = 5,
               Name = "East Ridge",
               StartingElevation = 10850,
               Distance = 3.4f,
               PeakId = 5
            });

         //   T o r r e y s   P e a k

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 6,
               Name = "Torreys Peak",
               Elevation = 14267
            });

         //   M t .   D e m o c r a t

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 7,
               Name = "Mt. Democrat",
               Elevation = 14148
            });

         //   M t .   E l b e r t

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 8,
               Name = "Mt. Elbert",
               Elevation = 14433,
               County = "Lake",
               NearestTown = "Leadville"
            });

         //   M t .   M a s s i v e

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 9,
               Name = "Mt. Massive",
               Elevation = 14421,
               County = "Lake",
               NearestTown = "Leadville"
            });

         //   M t .   H a r v a r d

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 10,
               Name = "Mt. Harvard",
               Elevation = 14420,
               County = "Chaffee",
               NearestTown = "Buena Vista"
            });

         //   B l a n c a   P e a k

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 11,
               Name = "Blanca Peak",
               Elevation = 14345,
               NearestTown = "Alamosa"
            });

         //   L a   P l a t a   P e a k

         modelBuilder.Entity<Peak>().HasData
            (new Peak
            {
               Id = 12,
               Name = "La Plata Peak",
               Elevation = 14345,
               NearestTown = "Alamosa"
            });
      }
   }
}
