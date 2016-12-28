using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WindLog.Models;

namespace WindLog.Migrations
{
    [DbContext(typeof(WindlogContext))]
    [Migration("20161228185838_Initialdatabase")]
    partial class Initialdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WindLog.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<DateTime>("Created");

                    b.Property<int?>("MaterialTypeId");

                    b.Property<string>("Memo");

                    b.Property<string>("Model");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Purchase");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("MaterialTypeId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("WindLog.Models.MaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Memo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MaterialTypes");
                });

            modelBuilder.Entity("WindLog.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Memo");

                    b.Property<string>("Name");

                    b.Property<DateTime>("SessionDate");

                    b.Property<int?>("SpotId");

                    b.HasKey("Id");

                    b.HasIndex("SpotId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("WindLog.Models.SessionMaterials", b =>
                {
                    b.Property<int>("SessionId");

                    b.Property<int>("MaterialId");

                    b.HasKey("SessionId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionMaterials");
                });

            modelBuilder.Entity("WindLog.Models.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<double>("Lat");

                    b.Property<double>("Long");

                    b.Property<string>("Memo");

                    b.Property<string>("Name");

                    b.Property<string>("Province");

                    b.HasKey("Id");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("WindLog.Models.Material", b =>
                {
                    b.HasOne("WindLog.Models.MaterialType", "MaterialType")
                        .WithMany()
                        .HasForeignKey("MaterialTypeId");
                });

            modelBuilder.Entity("WindLog.Models.Session", b =>
                {
                    b.HasOne("WindLog.Models.Spot", "Spot")
                        .WithMany()
                        .HasForeignKey("SpotId");
                });

            modelBuilder.Entity("WindLog.Models.SessionMaterials", b =>
                {
                    b.HasOne("WindLog.Models.Material", "Material")
                        .WithMany("SessionMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WindLog.Models.Session", "Session")
                        .WithMany("SessionMaterials")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
