﻿// <auto-generated />
using System;
using MachineSimulation.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MachineSimulation.DataAccess.Migrations
{
    [DbContext(typeof(MachineSimulationContext))]
    partial class MachineSimulationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MachineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.MachineLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MachineLogs");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OperationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.OperationParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("ParameterId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.HasIndex("ParameterId");

                    b.ToTable("OperationParameters");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.Operation", b =>
                {
                    b.HasOne("MachineSimulation.Entities.Concrete.Machine", "Machine")
                        .WithMany("Operations")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.OperationParameter", b =>
                {
                    b.HasOne("MachineSimulation.Entities.Concrete.Operation", "Operation")
                        .WithMany("OperationParameters")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachineSimulation.Entities.Concrete.Parameter", "Parameter")
                        .WithMany("OperationParameters")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Operation");

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.Parameter", b =>
                {
                    b.HasOne("MachineSimulation.Entities.Concrete.Machine", "Machine")
                        .WithMany("Parameters")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.Machine", b =>
                {
                    b.Navigation("Operations");

                    b.Navigation("Parameters");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.Operation", b =>
                {
                    b.Navigation("OperationParameters");
                });

            modelBuilder.Entity("MachineSimulation.Entities.Concrete.Parameter", b =>
                {
                    b.Navigation("OperationParameters");
                });
#pragma warning restore 612, 618
        }
    }
}
