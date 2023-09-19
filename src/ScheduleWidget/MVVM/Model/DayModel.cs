using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWidget.MVVM.Model
{
    internal class DayModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }

        public string Name { get; set; }

        public List<LessonModel> Lessons { get; set; }



    }
}
