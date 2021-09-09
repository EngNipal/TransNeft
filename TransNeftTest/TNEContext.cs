using Microsoft.EntityFrameworkCore;
using TransNeftTest.Models;

namespace TransNeftTest
{
    /// <summary> Контекст данных модели. </summary>
    public class TNEContext : DbContext
    {
        public DbSet<IdentifiedObject> IdentifiedObjects { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<EObject> EObjects { get; set; }
        public DbSet<MeterPoint> MeterPoints { get; set; }
        public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<ElectricityMeter> ElectricityMeters { get; set; }
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
        public DbSet<CalcMeter> CalcMeters { get; set; }



        public TNEContext(DbContextOptions<TNEContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.ChildrenOrganizations)
                .WithOne(co => co.ParentOrganization)
                .HasForeignKey(co => co.ParentOrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EObject>()
                .HasOne(e => e.ParentOrganization)
                .WithMany(po => po.EObjects)
                .HasForeignKey(po => po.ParentOrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MeterPoint>()
                .HasOne(mp => mp.EObject)
                .WithMany(c => c.MeterPoints)
                .HasForeignKey(mp => mp.EObjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MeterPoint>()
                .HasOne(mp => mp.CalcMeter)
                .WithOne(cm => cm.MeterPoint)
                .HasForeignKey<MeterPoint>(mp => mp.CalcMeterId);

            modelBuilder.Entity<DeliveryPoint>()
                .HasOne(dp => dp.EObject)
                .WithMany(c => c.DeliveryPoints)
                .HasForeignKey(dp => dp.EObjectId)
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

            modelBuilder.Entity<CalcMeter>()
                .HasOne(cm => cm.MeterPoint)
                .WithOne(mp => mp.CalcMeter)
                .HasForeignKey<CalcMeter>(cm => cm.MeterPointId);
        }
    }
}