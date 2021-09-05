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
        public DbSet<ElectricityMeter> ElectricityMeters { get; set; }
        public DbSet<Device> Devices { get; set; }
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
                .HasForeignKey(s => s.HoldingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subsidiary>()
                .HasMany(s => s.Consumers)
                .WithOne(c => c.Subsidiary)
                .HasForeignKey(c => c.SubsidiaryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MeterPoint>()
                .HasOne(mp => mp.Consumer)
                .WithMany(c => c.MeterPoints)
                .HasForeignKey(mp => mp.ConsumerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DeliveryPoint>()
                .HasOne(dp => dp.Consumer)
                .WithMany(c => c.DeliveryPoints)
                .HasForeignKey(dp => dp.ConsumerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ElectricityMeter>()
                .HasOne(em => em.MeterPoint)
                .WithOne(mp => mp.ElectricityMeter)
                .HasForeignKey<ElectricityMeter>(em => em.MeterPointId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CurrentTransformer>()
                .HasOne(ct => ct.MeterPoint)
                .WithOne(mp => mp.CurrentTransformer)
                .HasForeignKey<CurrentTransformer>(ct => ct.MeterPointId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VoltageTransformer>()
                .HasOne(vt => vt.MeterPoint)
                .WithOne(mp => mp.VoltageTransformer)
                .HasForeignKey<VoltageTransformer>(vt => vt.MeterPointId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CalcMeter>()
                .HasOne(cm => cm.DeliveryPoint)
                .WithOne(dp => dp.CalcMeter)
                .HasForeignKey<CalcMeter>(cm => cm.DeliveryPointId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
