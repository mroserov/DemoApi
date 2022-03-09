using Demo.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Dal
{
    public class DataContext : DbContext
    {
        #region Properties

        public DbSet<Step>? Steps { get; set; }
        public DbSet<DemoTask> DemoTasks { get; set; }

        #endregion

        #region Constructors
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Step>(
                builder =>
                {
                    builder
                    .HasOne(c => c.DemoTask)
                    .WithMany(s => s.Steps)
                    .HasForeignKey(c => c.DemoTaskId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<DemoTask>(
                builder =>
                {
                    builder
                    .Property(r => r.CreatedDate)
                    .HasDefaultValue(DateTime.Now);
                });
        }

        #endregion

    }
}