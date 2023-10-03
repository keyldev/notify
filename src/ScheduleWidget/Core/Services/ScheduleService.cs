using Microsoft.EntityFrameworkCore;
using ScheduleWidget.Core.Data;
using ScheduleWidget.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleWidget.Core.Services
{
    internal class ScheduleService
    {

        private readonly ApplicationDbContext _dbContext;

        public ScheduleService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public void CreateSchedule(ScheduleModel schedule)
        {
            _dbContext.Schedules.Add(schedule);
            _dbContext.SaveChanges();
        }

        public void EditSchedule(ScheduleModel schedule)
        {
            _dbContext.Schedules.Update(schedule);
            _dbContext.SaveChanges();
        }

        public void CreateDay(DayModel day)
        {
            _dbContext.Days.Add(day);
            _dbContext.SaveChanges();
        }

        public List<DayModel> GetDaysById(int id)
        {
            return _dbContext.Days.Where(d=> d.ScheduleId == id).ToList();
        }

        public void EditDay(DayModel day)
        {
            _dbContext.Days.Update(day);
            _dbContext.SaveChanges();
        }

        public void CreateLesson(LessonModel lesson)
        {
            _dbContext.Lessons.Add(lesson);
            _dbContext.SaveChanges();
        }

        public void EditLesson(LessonModel lesson)
        {
            _dbContext.Lessons.Update(lesson);
            _dbContext.SaveChanges();
        }

        public List<ScheduleModel> LoadSchedules()
        {
            return _dbContext.Schedules.Include(s => s.Days).ThenInclude(d => d.Lessons).ToList();
        }


    }
}
