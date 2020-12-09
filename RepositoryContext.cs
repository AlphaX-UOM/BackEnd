using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuggestorCodeFirstAPI.Configuration;
using SuggestorCodeFirstAPI.Models;

namespace SuggestorCodeFirstAPI
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.Entity<HotelServiceRoomType>()
                  .HasKey(cs => new { cs.HotelServiceId, cs.RoomTypeId});

            modelBuilder.Entity<TransportServiceComment>()
                .HasOne(t => t.TransportService)
                .WithMany(b => b.TransportServiceComments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransportServiceComment>()
                .HasOne(t => t.User)
                .WithMany(b => b.TransportServiceComments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TourGuideServiceComment>()
                .HasOne(t => t.TourGuideService)
                .WithMany(b => b.TourGuideServiceComments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TourGuideServiceComment>()
                .HasOne(t => t.User)
                .WithMany(b => b.TourGuideServiceComments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventPlannerServiceComment>()
                .HasOne(t => t.EventPlannerService)
                .WithMany(b => b.EventPlannerServiceComments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventPlannerServiceComment>()
                .HasOne(t => t.User)
                .WithMany(b => b.EventPlannerServiceComment)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HotelsServiceComment>()
                .HasOne(t => t.HotelsService)
                .WithMany(b => b.HotelsServiceComments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HotelsServiceComment>()
                .HasOne(t => t.User)
                .WithMany(b => b.HotelsServiceComment)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<Cancellation> Cancellations { get; set; }
        public DbSet<EventPlannerService> EventPlannerServices { get; set; }
        public DbSet<EventPlannerServiceComment> EventPlannerServiceComments { get; set; }
        public DbSet<EventPlannerServiceReservation> EventPlannerServiceReservations { get; set; }
        public DbSet<HotelsService> HotelsServices { get; set; }
        public DbSet<HotelsServiceComment> HotelsServiceComments { get; set; }
        public DbSet<HotelsServiceReservation> HotelsServiceReservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<TourGuideService> TourGuideServices { get; set; }
        public DbSet<TourGuideServiceComment> TourGuideServiceComments { get; set; }
        public DbSet<TourGuideServiceReservation> TourGuideServiceReservations { get; set; }
        public DbSet<TransportService> TransportServices { get; set; }
        public DbSet<TransportServiceComment> TransportServiceComments { get; set; }
        public DbSet<TransportServiceReservation> TransportServiceReservations { get; set; }
        public DbSet<HotelServiceRoomType> HotelServiceRoomTypes { get; set; }
        public DbSet<User> Users { get; set; }

        

    }

}
