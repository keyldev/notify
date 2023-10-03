using ScheduleWidget.Core.Data;
using ScheduleWidget.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWidget.Core.Services
{
    internal class ScheduleService
    {

        public List<ScheduleModel> LoadAvialableSchedules()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Schedules.ToList();
            }
        }

        public List<DayModel> GetDaysInfo(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var days = db.Days.Where(d=>d.ScheduleId == id).ToList();
                return days;

            }
        }


    }
}
