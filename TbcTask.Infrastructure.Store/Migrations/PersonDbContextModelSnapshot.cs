﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TbcTask.Infrastructure.Store;

#nullable disable

namespace TbcTask.Infrastructure.Store.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    partial class PersonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TbcTask.Domain.Models.Database.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tbilisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rustavi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Batumi"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kutaisi"
                        });
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.ConnectedPersons", b =>
                {
                    b.Property<int>("PhysicialPersonId")
                        .HasColumnType("int");

                    b.Property<int>("ConnectedPersonId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PersonConnectionTypeID")
                        .HasColumnType("int");

                    b.HasKey("PhysicialPersonId", "ConnectedPersonId")
                        .HasName("DualValidation");

                    b.HasIndex("ConnectedPersonId");

                    b.HasIndex("PersonConnectionTypeID");

                    b.ToTable("ConnectedPersons");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.PersonConnectionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonConnectionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Collegue"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Relative"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Familiar"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneTypeID")
                        .HasColumnType("int");

                    b.Property<int>("PhysicalPersonID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhoneTypeID");

                    b.HasIndex("PhysicalPersonID");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.PhoneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhoneTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Home"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Office"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mobile"
                        });
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.PhysicalPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<string>("ImageAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PrivateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityID");

                    b.HasIndex("GenderID");

                    b.ToTable("PhysicalPersons");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.ConnectedPersons", b =>
                {
                    b.HasOne("TbcTask.Domain.Models.Database.PhysicalPerson", "ConnectedPerson")
                        .WithMany("ConnectedPersons")
                        .HasForeignKey("ConnectedPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TbcTask.Domain.Models.Database.PersonConnectionType", "PersonConnectionType")
                        .WithMany("ConnectedPerson")
                        .HasForeignKey("PersonConnectionTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TbcTask.Domain.Models.Database.PhysicalPerson", "PhysicialPerson")
                        .WithMany()
                        .HasForeignKey("PhysicialPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ConnectedPerson");

                    b.Navigation("PersonConnectionType");

                    b.Navigation("PhysicialPerson");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.Phone", b =>
                {
                    b.HasOne("TbcTask.Domain.Models.Database.PhoneType", "PhoneType")
                        .WithMany("Phones")
                        .HasForeignKey("PhoneTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TbcTask.Domain.Models.Database.PhysicalPerson", "PhysicalPerson")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PhysicalPersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhoneType");

                    b.Navigation("PhysicalPerson");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.PhysicalPerson", b =>
                {
                    b.HasOne("TbcTask.Domain.Models.Database.City", "City")
                        .WithMany("PhysicalPersons")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TbcTask.Domain.Models.Database.Gender", "Gender")
                        .WithMany("PhysicalPersons")
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.City", b =>
                {
                    b.Navigation("PhysicalPersons");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.Gender", b =>
                {
                    b.Navigation("PhysicalPersons");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.PersonConnectionType", b =>
                {
                    b.Navigation("ConnectedPerson");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.PhoneType", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("TbcTask.Domain.Models.Database.PhysicalPerson", b =>
                {
                    b.Navigation("ConnectedPersons");

                    b.Navigation("PhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
