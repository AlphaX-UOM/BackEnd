using System;
using System.Collections.Generic;
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
        public DbSet<TransportType> TransportTypes { get; set; }
        public DbSet<User> Users { get; set; }

        

    }

}
