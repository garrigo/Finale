// <auto-generated />
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Backend.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Backend.Models.Deed", b =>
                {
                    b.Property<int>("DeedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("NotaryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeedId");

                    b.HasIndex("ClientId");

                    b.HasIndex("NotaryId");

                    b.HasIndex("RealEstateId");

                    b.ToTable("Deeds");
                });

            modelBuilder.Entity("Backend.Models.Notary", b =>
                {
                    b.Property<int>("NotaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("NotaryId");

                    b.ToTable("Notaries");
                });

            modelBuilder.Entity("Backend.Models.RealEstate", b =>
                {
                    b.Property<int>("RealEstateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Mq")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("RealEstateId");

                    b.ToTable("RealEstates");
                });

            modelBuilder.Entity("Backend.Models.Deed", b =>
                {
                    b.HasOne("Backend.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Notary", "Notary")
                        .WithMany()
                        .HasForeignKey("NotaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.RealEstate", "RealEstate")
                        .WithMany()
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Notary");

                    b.Navigation("RealEstate");
                });
#pragma warning restore 612, 618
        }
    }
}
