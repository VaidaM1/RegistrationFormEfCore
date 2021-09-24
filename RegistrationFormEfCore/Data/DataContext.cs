using Microsoft.EntityFrameworkCore;
using RegistrationFormEfCore.Models;
using System.Collections.Generic;

namespace RegistrationFormEfCore.Data
{
    public class DataContext : DbContext
    {
        internal readonly IEnumerable<object> ShowRegistration;

        public DbSet<DropDownOption> DropDownOptions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SelectedValue> SelectedValues { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
            //mayhapps
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SelectedValue>()
                .HasKey(cb => new { cb.QuestionId, cb.DropDownOptionId });
            //modelBuilder.Entity<SelectedValue>()
            //    .HasOne(cb => cb.Question)
            //    .WithMany()
            //    .HasForeignKey(cb => cb.QuestionId);
            //modelBuilder.Entity<SelectedValue>()
            //    .HasOne(cb => cb.DropDownOption)
            //    .WithMany()
            //    .HasForeignKey(cb => cb.DropDownOptionId);

        }
    }
}
