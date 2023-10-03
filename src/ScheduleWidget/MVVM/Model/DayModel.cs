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
    internal class DayModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int ScheduleId { get; set; }
        public ScheduleModel Schedule { get; set; }
        public List<LessonModel> Lessons { get; set; }
    }
}
