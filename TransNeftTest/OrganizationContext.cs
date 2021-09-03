using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest
{
    /// <summary> Контекст данных модели. </summary>
    public class OrganizationContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Subsidiary> Subsidiaries { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<MeterPoint> MeterPoints { get; set; }
        public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public DbSet<ElictricityMeter> ElicticityMeters { get; set; }
        public DbSet<Device> Transformers { get; set; }
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
        public DbSet<CalcMeter> CalcMeters { get; set; }



        public OrganizationContext(DbContextOptions<OrganizationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Holding>()
                .HasMany(h => h.Subsidiaries)
                .WithOne(s => s.Holding)
                .HasForeignKey(s => s.HoldingId);

            modelBuilder.Entity<Subsidiary>()
                .HasMany(s => s.Consumers)
                .WithOne(c => c.Subsidiary)
                .HasForeignKey(c => c.SubsidiaryId);

            modelBuilder.Entity<MeterPoint>()
                .HasOne(m => m.Consumer)
                .WithMany(c => c.MeterPoints)
                .HasForeignKey(m => m.ConsumerId);

            modelBuilder.Entity<DeliveryPoint>()
                .HasOne(d => d.Consumer)
                .WithMany(c => c.DeliveryPoints)
                .HasForeignKey(d => d.ConsumerId);

            modelBuilder.Entity<ElictricityMeter>()
                .HasOne(e => e.MeterPoint)
                .WithOne(m => m.ElicticityMeter);

            modelBuilder.Entity<CurrentTransformer>()
                .HasOne(t => t.MeterPoint)
                .WithOne(m => m.CurrentTransformer);

            modelBuilder.Entity<VoltageTransformer>()
                .HasOne(t => t.MeterPoint)
                .WithOne(m => m.VoltageTransformer);

            modelBuilder.Entity<CalcMeter>()
                .HasOne(c => c.DeliveryPoint)
                .WithOne(d => d.CalcMeter);
        }
    }
}
