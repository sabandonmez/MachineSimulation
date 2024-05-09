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
        public DbSet<User> Users { get; set; }
        public DbSet<Stoppage> Stoppages { get; set; }
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
                    new Operation { Id = 1, MachineId = 1, OperationName = "Hazırlık Başlat", ModbusIp = 2280, Event = 1 },
                    new Operation { Id = 2, MachineId = 1, OperationName = "Hazırlık Bitir", ModbusIp = 2280, Event = 2 },
                    new Operation { Id = 3, MachineId = 1, OperationName = "Üretim Başlat", ModbusIp = 2273, Event = 3 },
                    new Operation { Id = 4, MachineId = 1, OperationName = "Üretim Bitir", ModbusIp = 2273, Event = 4 },

                    new Operation { Id = 13, MachineId = 1, OperationName = "Otomatik Üretim Başlat", Event = 5 },
                    new Operation { Id = 14, MachineId = 1, OperationName = "Otomatik Üretim Bitir", ModbusIp = 4206, Event = 6 },

                     new Operation { Id = 15, MachineId = 1, OperationName = "Duruş Başlat", ModbusIp = 2280, Event = 7 },
                    new Operation { Id = 16, MachineId = 1, OperationName = "Duruş Bitir", ModbusIp = 2280, Event = 8 },

                    new Operation { Id = 5, MachineId = 2, OperationName = "Hazırlık Başlat", ModbusIp = 2281, Event = 1 },
                    new Operation { Id = 6, MachineId = 2, OperationName = "Hazırlık Bitir", ModbusIp = 2281, Event = 2 },
                    new Operation { Id = 7, MachineId = 2, OperationName = "Üretim Başlat", ModbusIp = 2274, Event = 3 },
                    new Operation { Id = 8, MachineId = 2, OperationName = "Üretim Bitir", ModbusIp = 2274, Event = 4 },

                    new Operation { Id = 17, MachineId = 2, OperationName = "Otomatik Üretim Başlat",  Event = 5 },
                    new Operation { Id = 18, MachineId = 2, OperationName = "Otomatik Üretim Bitir", ModbusIp = 4206, Event = 6 },

                      new Operation { Id = 19, MachineId =2, OperationName = "Duruş Başlat", ModbusIp = 2280, Event = 7 },
                    new Operation { Id = 20, MachineId = 2, OperationName = "Duruş Bitir", ModbusIp = 2280, Event = 8 },

                    new Operation { Id = 9, MachineId = 3, OperationName = "Hazırlık Başlat", ModbusIp = 2282, Event = 1 },
                    new Operation { Id = 10, MachineId = 3, OperationName = "Hazırlık Bitir", ModbusIp = 2282, Event = 2 },
                    new Operation { Id = 11, MachineId = 3, OperationName = "Üretim Başlat", ModbusIp = 2275, Event = 3 },
                    new Operation { Id = 12, MachineId = 3, OperationName = "Üretim Bitir", ModbusIp = 2275, Event = 4 },

                    new Operation { Id = 21, MachineId = 3, OperationName = "Otomatik Üretim Başlat", Event = 5 },
                    new Operation { Id = 22, MachineId = 3, OperationName = "Otomatik Üretim Bitir", ModbusIp = 4206, Event = 6 },

                    new Operation { Id = 23, MachineId = 3, OperationName = "Duruş Başlat", ModbusIp = 2280, Event = 7 },
                    new Operation { Id = 24, MachineId = 3, OperationName = "Duruş Bitir", ModbusIp = 2280, Event = 8 }
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
            modelBuilder.Entity<Stoppage>()
           .HasData(
            new Stoppage { Id=1,MachineId=1,ReasonStoppageName="Bakım Arıza",ReasonStoppageValue=45},
            new Stoppage { Id = 2, MachineId = 1, ReasonStoppageName = "Planlı Duruş", ReasonStoppageValue = 60 },
            new Stoppage { Id = 3, MachineId = 1, ReasonStoppageName = "Deneme Duruşu", ReasonStoppageValue = 5 }
           );

        }

    }
}
