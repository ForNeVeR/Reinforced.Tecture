﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reinforced.Samples.ToyFactory.Data;

namespace Reinforced.Samples.ToyFactory.Data.Migrations
{
    [DbContext(typeof(ToyFactoryDbContext))]
    partial class ToyFactoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reinforced.Samples.ToyFactory.Logic.Entities.Blueprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ToyTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToyTypeId");

                    b.ToTable("Blueprints");
                });

            modelBuilder.Entity("Reinforced.Samples.ToyFactory.Logic.Entities.BlueprintResources", b =>
                {
                    b.Property<int>("BlueprintId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("BlueprintId", "ResourceId");

                    b.HasIndex("ResourceId");

                    b.ToTable("BlueprintResources");
                });

            modelBuilder.Entity("Reinforced.Samples.ToyFactory.Logic.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Reinforced.Samples.ToyFactory.Logic.Entities.ToyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ToyTypes");
                });

            modelBuilder.Entity("Reinforced.Samples.ToyFactory.Logic.Entities.Blueprint", b =>
                {
                    b.HasOne("Reinforced.Samples.ToyFactory.Logic.Entities.ToyType", "ToyType")
                        .WithMany()
                        .HasForeignKey("ToyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reinforced.Samples.ToyFactory.Logic.Entities.BlueprintResources", b =>
                {
                    b.HasOne("Reinforced.Samples.ToyFactory.Logic.Entities.Blueprint", "Blueprint")
                        .WithMany()
                        .HasForeignKey("BlueprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reinforced.Samples.ToyFactory.Logic.Entities.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
