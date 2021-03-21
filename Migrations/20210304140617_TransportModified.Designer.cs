﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuggestorCodeFirstAPI;

namespace SuggestorCodeFirstAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210304140617_TransportModified")]
    partial class TransportModified
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.Cancellation", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ReservationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ReservationID")
                        .IsUnique()
                        .HasFilter("[ReservationID] IS NOT NULL");

                    b.HasIndex("UserID");

                    b.ToTable("Cancellations");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.EventPlannerService", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Venue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("EventPlannerServices");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.EventPlannerServiceComment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EventPlannerServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("EventPlannerServiceID");

                    b.HasIndex("UserID");

                    b.ToTable("EventPlannerServiceComments");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.HotelServiceRoomType", b =>
                {
                    b.Property<Guid?>("HotelServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HotelsServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HotelServiceId", "RoomTypeId");

                    b.HasIndex("HotelsServiceID");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("HotelServiceRoomTypes");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.HotelsService", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Features")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("RoomTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Venue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RoomTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("HotelsServices");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.HotelsServiceComment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("HotelsServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("HotelsServiceID");

                    b.HasIndex("UserID");

                    b.ToTable("HotelsServiceComments");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.Payment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.Reservation", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfTravellers")
                        .HasColumnType("int");

                    b.Property<Guid?>("PaymentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("PaymentID");

                    b.HasIndex("UserID");

                    b.ToTable("Reservations");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Reservation");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.RoomType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BasePricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfGuests")
                        .HasColumnType("int");

                    b.Property<string>("Specs")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TourGuideService", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CostPerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("TourGuideServices");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TourGuideServiceComment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid?>("TourGuideServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("TourGuideServiceID");

                    b.HasIndex("UserID");

                    b.ToTable("TourGuideServiceComments");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TransportService", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AirCondition")
                        .HasColumnType("bit");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoOfSeats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PricePer1KM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehicleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("TransportServices");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TransportServiceComment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid?>("TransportServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("TransportServiceID");

                    b.HasIndex("UserID");

                    b.ToTable("TransportServiceComments");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Address = "N0:198/3, Airport Road, Minuwangoda",
                            Contact = "0715510491",
                            DOB = "1996/07/27",
                            Email = "gdsudam@gmail.com",
                            FirstName = "Sudam",
                            LastName = "Yasodya",
                            Password = "123",
                            Role = "Admin"
                        },
                        new
                        {
                            ID = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991871"),
                            Address = "N0:198/3, Airport Road, Minuwangoda, Gampaha",
                            Contact = "0112294169",
                            DOB = "1996/07/28",
                            Email = "gdsudam@gmail.com.com",
                            FirstName = "Sudama",
                            LastName = "Yasodyaa",
                            Password = "1234",
                            Role = "Customer"
                        },
                        new
                        {
                            ID = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991875"),
                            Address = "N0:198/3, Airport Road, Malabe",
                            Contact = "071556223",
                            DOB = "1997/03/31",
                            Email = "rasmi@gmail.com",
                            FirstName = "Rasmi",
                            LastName = "Duli",
                            Password = "123123",
                            Role = "ServiceProvider"
                        });
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.EventPlannerServiceReservation", b =>
                {
                    b.HasBaseType("SuggestorCodeFirstAPI.Models.Reservation");

                    b.Property<Guid?>("EventPlannerServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("EventPlannerServiceID");

                    b.HasDiscriminator().HasValue("EventPlannerServiceReservation");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.HotelsServiceReservation", b =>
                {
                    b.HasBaseType("SuggestorCodeFirstAPI.Models.Reservation");

                    b.Property<Guid?>("HotelsServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NoOfRooms")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("HotelsServiceID");

                    b.HasDiscriminator().HasValue("HotelsServiceReservation");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TourGuideServiceReservation", b =>
                {
                    b.HasBaseType("SuggestorCodeFirstAPI.Models.Reservation");

                    b.Property<Guid?>("TourGuideServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("TourGuideServiceID");

                    b.HasDiscriminator().HasValue("TourGuideServiceReservation");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TransportServiceReservation", b =>
                {
                    b.HasBaseType("SuggestorCodeFirstAPI.Models.Reservation");

                    b.Property<string>("DropOffLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DropOffTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NoOfPassengers")
                        .HasColumnType("int");

                    b.Property<string>("PickUpLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PickUpTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TransportServiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehicleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("TransportServiceID");

                    b.HasDiscriminator().HasValue("TransportServiceReservation");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.Cancellation", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.Reservation", "Reservation")
                        .WithOne("Cancellation")
                        .HasForeignKey("SuggestorCodeFirstAPI.Models.Cancellation", "ReservationID");

                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("Cancellations")
                        .HasForeignKey("UserID");

                    b.Navigation("Reservation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.EventPlannerService", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("EventPlannerServices")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.EventPlannerServiceComment", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.EventPlannerService", "EventPlannerService")
                        .WithMany("EventPlannerServiceComments")
                        .HasForeignKey("EventPlannerServiceID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("EventPlannerServiceComment")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("EventPlannerService");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.HotelServiceRoomType", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.HotelsService", "HotelsService")
                        .WithMany("HotelServiceRoomTypes")
                        .HasForeignKey("HotelsServiceID");

                    b.HasOne("SuggestorCodeFirstAPI.Models.RoomType", "RoomType")
                        .WithMany("HotelServiceRoomTypes")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelsService");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.HotelsService", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeID");

                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("HotelsServices")
                        .HasForeignKey("UserID");

                    b.Navigation("RoomType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.HotelsServiceComment", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.HotelsService", "HotelsService")
                        .WithMany("HotelsServiceComments")
                        .HasForeignKey("HotelsServiceID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("HotelsServiceComment")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("HotelsService");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.Payment", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.Reservation", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.Payment", "Payment")
                        .WithMany("Reservations")
                        .HasForeignKey("PaymentID");

                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserID");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TourGuideService", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("TourGuideServices")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TourGuideServiceComment", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.TourGuideService", "TourGuideService")
                        .WithMany("TourGuideServiceComments")
                        .HasForeignKey("TourGuideServiceID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("TourGuideServiceComments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("TourGuideService");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TransportService", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("TransportServices")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TransportServiceComment", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.TransportService", "TransportService")
                        .WithMany("TransportServiceComments")
                        .HasForeignKey("TransportServiceID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SuggestorCodeFirstAPI.Models.User", "User")
                        .WithMany("TransportServiceComments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("TransportService");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.EventPlannerServiceReservation", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.EventPlannerService", "EventPlannerService")
                        .WithMany("EventPlannerServiceReservations")
                        .HasForeignKey("EventPlannerServiceID");

                    b.Navigation("EventPlannerService");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.HotelsServiceReservation", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.HotelsService", "HotelsService")
                        .WithMany("HotelsServiceReservations")
                        .HasForeignKey("HotelsServiceID");

                    b.Navigation("HotelsService");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TourGuideServiceReservation", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.TourGuideService", "TourGuideService")
                        .WithMany("TourGuideServiceReservations")
                        .HasForeignKey("TourGuideServiceID");

                    b.Navigation("TourGuideService");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TransportServiceReservation", b =>
                {
                    b.HasOne("SuggestorCodeFirstAPI.Models.TransportService", "TransportService")
                        .WithMany("TransportServiceReservations")
                        .HasForeignKey("TransportServiceID");

                    b.Navigation("TransportService");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.EventPlannerService", b =>
                {
                    b.Navigation("EventPlannerServiceComments");

                    b.Navigation("EventPlannerServiceReservations");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.HotelsService", b =>
                {
                    b.Navigation("HotelServiceRoomTypes");

                    b.Navigation("HotelsServiceComments");

                    b.Navigation("HotelsServiceReservations");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.Payment", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.Reservation", b =>
                {
                    b.Navigation("Cancellation");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.RoomType", b =>
                {
                    b.Navigation("HotelServiceRoomTypes");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TourGuideService", b =>
                {
                    b.Navigation("TourGuideServiceComments");

                    b.Navigation("TourGuideServiceReservations");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.TransportService", b =>
                {
                    b.Navigation("TransportServiceComments");

                    b.Navigation("TransportServiceReservations");
                });

            modelBuilder.Entity("SuggestorCodeFirstAPI.Models.User", b =>
                {
                    b.Navigation("Cancellations");

                    b.Navigation("EventPlannerServiceComment");

                    b.Navigation("EventPlannerServices");

                    b.Navigation("HotelsServiceComment");

                    b.Navigation("HotelsServices");

                    b.Navigation("Reservations");

                    b.Navigation("TourGuideServiceComments");

                    b.Navigation("TourGuideServices");

                    b.Navigation("TransportServiceComments");

                    b.Navigation("TransportServices");
                });
#pragma warning restore 612, 618
        }
    }
}