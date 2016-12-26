using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WindLog.Models;

namespace WindLog.Migrations
{
    [DbContext(typeof(WindlogContext))]
    [Migration("20161226185027_Initialdatabase")]
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

                    b.Property<int?>("SessionId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("MaterialTypeId");

                    b.HasIndex("SessionId");

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
                        .WithMany("Materials")
                        .HasForeignKey("MaterialTypeId");

                    b.HasOne("WindLog.Models.Session")
                        .WithMany("Materials")
                        .HasForeignKey("SessionId");
                });

            modelBuilder.Entity("WindLog.Models.Session", b =>
                {
                    b.HasOne("WindLog.Models.Spot", "Spot")
                        .WithMany("Sessions")
                        .HasForeignKey("SpotId");
                });
        }
    }
}
