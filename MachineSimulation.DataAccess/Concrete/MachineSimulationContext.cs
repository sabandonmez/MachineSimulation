using MachineSimulation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete
{
    public class MachineSimulationContext : DbContext
    {
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<OperationParameter> OperationParameters { get; set; }
        public DbSet<MachineLog> MachineLogs { get; set; }
        public DbSet<OperationLog> OperationLogs { get; set; }
        public MachineSimulationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OperationParameter>()
                .HasOne(op => op.Operation)
                .WithMany(o => o.OperationParameters)
                .HasForeignKey(op => op.OperationId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<OperationParameter>()
                .HasOne(op => op.Parameter)
                .WithMany(p => p.OperationParameters)
                .HasForeignKey(op => op.ParameterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Machine>()
                .HasData(
                    new Machine { Id=1,MachineName = "Plastik Enjeksiyon", MachineType = "enjeksiyon", ProductionCount = 0, ImageUrl = "PlastikEnjeksiyon.jpg", ModbusId = 4096 },
                    new Machine { Id = 2, MachineName = "Kitamura Cnc Tezgahı", MachineType = "cnc", ProductionCount = 0, ImageUrl = "KitamuraCncTezgahı.jpg", ModbusId = 4097 },
                    new Machine { Id = 3, MachineName = "Abkant Press", MachineType = "press", ProductionCount = 0, ImageUrl = "AbkantPress.jpg", ModbusId = 4098 }
            );

            modelBuilder.Entity<Operation>()
                .HasData(
                    new Operation { Id = 1, MachineId = 1, OperationName = "Hazırlık Başlat", ModbusIp = 4249, Event = 1 },
                    new Operation { Id = 2, MachineId = 1, OperationName = "Hazırlık Bitir", ModbusIp = 4249, Event = 2 },
                    new Operation { Id = 3, MachineId = 1, OperationName = "Üretim Başlat", ModbusIp = 4255, Event = 3 },
                    new Operation { Id = 4, MachineId = 1, OperationName = "Üretim Bitir", ModbusIp = 4255, Event = 4 },
                    new Operation { Id = 5, MachineId = 2, OperationName = "Hazırlık Başlat", ModbusIp = 4250, Event = 1 },
                    new Operation { Id = 6, MachineId = 2, OperationName = "Hazırlık Bitir", ModbusIp = 4250, Event = 2 },
                    new Operation { Id = 7, MachineId = 2, OperationName = "Üretim Başlat", ModbusIp = 4256, Event = 3 },
                    new Operation { Id = 8, MachineId = 2, OperationName = "Üretim Bitir", ModbusIp = 4256, Event = 4 },
                    new Operation { Id = 9, MachineId = 3, OperationName = "Hazırlık Başlat", ModbusIp = 4251, Event = 1 },
                    new Operation { Id = 10, MachineId = 3, OperationName = "Hazırlık Bitir", ModbusIp = 4251, Event = 2 },
                    new Operation { Id = 11, MachineId = 3, OperationName = "Üretim Başlat", ModbusIp = 4257, Event = 3 },
                    new Operation { Id = 12, MachineId = 3, OperationName = "Üretim Bitir", ModbusIp = 4257, Event = 4 }
            );
            modelBuilder.Entity<Parameter>()
               .HasData(
                  new Parameter { Id = 1, MachineId = 1, ParameterName = "Hız", ValueType = "int" },
                  new Parameter { Id = 2, MachineId = 1, ParameterName = "Sıcaklık", ValueType = "int" },
                  new Parameter { Id = 3, MachineId = 2, ParameterName = "Hız", ValueType = "int" },
                  new Parameter { Id = 4, MachineId = 2, ParameterName = "Sıcaklık", ValueType = "int" },
                  new Parameter { Id = 5, MachineId = 3, ParameterName = "Cnc Ilerleme Hizi", ValueType = "int" },
                  new Parameter { Id = 6, MachineId = 3, ParameterName = "Ariza Alarm Sayisi", ValueType = "int" }
           );

        }

    }
}
