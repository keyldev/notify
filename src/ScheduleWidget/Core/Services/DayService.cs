using ScheduleWidget.Core.Data;
using ScheduleWidget.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWidget.Core.Services
{
    class DayService
    {

        private readonly ApplicationDbContext _dbContext;

        public DayService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public List<LessonModel> LoadDayLessonsById(int id)
        {
            return _dbContext.Lessons.Where(l => l.DayId == id).ToList();
        }

        internal string GetDayNameById(int dayId)
        {
            return _dbContext.Days.Where(d => d.Id == dayId).First().Name;
        }

        internal void SaveLessons(List<LessonModel> lessonModels)
        {
            _dbContext.UpdateRange(lessonModels);
            _dbContext.SaveChanges();
        }
    }
}
