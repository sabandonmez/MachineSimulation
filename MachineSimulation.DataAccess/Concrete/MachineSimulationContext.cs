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
        DbSet<Machine> Machines { get; set; }
        DbSet<Operation> Operations { get; set; }
        DbSet<Parameter> Parameters { get; set; }
        DbSet<OperationParameter> OperationParameters { get; set; }

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
