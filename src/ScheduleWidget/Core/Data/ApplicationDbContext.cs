using Microsoft.EntityFrameworkCore;
using ScheduleWidget.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWidget.Core.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<LessonModel> Lessons { get; set; }
        public DbSet<DayModel> Days { get; set; }
        public DbSet<ScheduleModel> Schedules { get; set; }
        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=local.db");
            base.OnConfiguring(optionsBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

    }
}
