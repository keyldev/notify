using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWidget.MVVM.Model
{
    internal class LessonModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid DayId { get; set; }
        public string? Name { get; set; }

        public int Number { get; set; } = 1;
        public string? Classroom { get; set; }
        public string? TeacherName { get; set; }
        public bool IsLecture { get; set; } = true;



    }
}
