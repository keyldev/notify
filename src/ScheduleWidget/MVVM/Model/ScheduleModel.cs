using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWidget.MVVM.Model
{
    internal class ScheduleModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<DayModel> Days { get; set; }
        public bool IsEvenWeek { get; set; } = true;

    }
}
