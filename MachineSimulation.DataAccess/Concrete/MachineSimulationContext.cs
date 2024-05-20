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
                    new Machine { Id=1,MachineName = "Plastik Enjeksiyon",ImageUrl = "PlastikEnjeksiyon.jpg", ModbusId = 4096 },
                    new Machine { Id = 2, MachineName = "Kitamura Cnc Tezgahı",ImageUrl = "KitamuraCncTezgahı.jpg", ModbusId = 4097 },
                    new Machine { Id = 3, MachineName = "Abkant Press", ImageUrl = "AbkantPress.jpg", ModbusId = 4098 }
            );


			modelBuilder.Entity<OperationName>().HasData(
	          new OperationName { Id = 1, Name = "Hazırlık Başlat" },
	          new OperationName { Id = 2, Name = "Hazırlık Bitir" },
	          new OperationName { Id = 3, Name = "Üretim Başlat" },
	          new OperationName { Id = 4, Name = "Üretim Bitir" },
	          new OperationName { Id = 5, Name = "Otomatik Üretim Başlat" },
	          new OperationName { Id = 6, Name = "Otomatik Üretim Bitir" },
	          new OperationName { Id = 7, Name = "Duruş Başlat" },
	          new OperationName { Id = 8, Name = "Duruş Bitir" }
            );



			modelBuilder.Entity<Operation>().HasData(
		new Operation { Id = 1, MachineId = 1, OperationNameId = 1, ModbusIp = 2280 },
		new Operation { Id = 2, MachineId = 1, OperationNameId = 2, ModbusIp = 2280 },
		new Operation { Id = 3, MachineId = 1, OperationNameId = 3, ModbusIp = 2273 },
		new Operation { Id = 4, MachineId = 1, OperationNameId = 4, ModbusIp = 2273 },
		new Operation { Id = 13, MachineId = 1, OperationNameId = 5},
		new Operation { Id = 14, MachineId = 1, OperationNameId = 6, ModbusIp = 4206 },
		new Operation { Id = 15, MachineId = 1, OperationNameId = 7, ModbusIp = 2280 },
		new Operation { Id = 16, MachineId = 1, OperationNameId = 8, ModbusIp = 2280 },
		new Operation { Id = 5, MachineId = 2, OperationNameId = 1, ModbusIp = 2281 },
		new Operation { Id = 6, MachineId = 2, OperationNameId = 2, ModbusIp = 2281 },
		new Operation { Id = 7, MachineId = 2, OperationNameId = 3, ModbusIp = 2274 },
		new Operation { Id = 8, MachineId = 2, OperationNameId = 4, ModbusIp = 2274 },
		new Operation { Id = 17, MachineId = 2, OperationNameId = 5},
		new Operation { Id = 18, MachineId = 2, OperationNameId = 6, ModbusIp = 4206 },
		new Operation { Id = 19, MachineId = 2, OperationNameId = 7, ModbusIp = 2280 },
		new Operation { Id = 20, MachineId = 2, OperationNameId = 8, ModbusIp = 2280 },
		new Operation { Id = 9, MachineId = 3, OperationNameId = 1, ModbusIp = 2282 },
		new Operation { Id = 10, MachineId = 3, OperationNameId = 2, ModbusIp = 2282 },
		new Operation { Id = 11, MachineId = 3, OperationNameId = 3, ModbusIp = 2275 },
		new Operation { Id = 12, MachineId = 3, OperationNameId = 4, ModbusIp = 2275 },
		new Operation { Id = 21, MachineId = 3, OperationNameId = 5 },
		new Operation { Id = 22, MachineId = 3, OperationNameId = 6, ModbusIp = 4206 },
		new Operation { Id = 23, MachineId = 3, OperationNameId = 7, ModbusIp = 2280 },
		new Operation { Id = 24, MachineId = 3, OperationNameId = 8, ModbusIp = 2280 }
	);
			modelBuilder.Entity<Parameter>()
               .HasData(
                  new Parameter { Id = 1, MachineId = 1, ParameterName = "Hız" },
                  new Parameter { Id = 2, MachineId = 1, ParameterName = "Sıcaklık" },
                  new Parameter { Id = 3, MachineId = 2, ParameterName = "Hız" },
                  new Parameter { Id = 4, MachineId = 2, ParameterName = "Sıcaklık" },
                  new Parameter { Id = 5, MachineId = 3, ParameterName = "Cnc Ilerleme Hizi" },
                  new Parameter { Id = 6, MachineId = 3, ParameterName = "Ariza Alarm Sayisi" }
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
