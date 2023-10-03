using ScheduleWidget.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWidget.MVVM.Model
{
    internal class LessonModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Какая-то пара";
        public int Number { get; set; } = 1;
        public string? Classroom { get; set; } = "0A";
        public string? TeacherName { get; set; } = "Иванов И.И.";
        [NotMapped]
        public string LessonTime { get; set; } = "8:00 - 9:30";
        public int DayId { get; set; }
        [NotMapped]
        public RelayCommand DeleteElementCommand { get; set; }

    }
}
