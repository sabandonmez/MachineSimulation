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
        }
     
    }
}
