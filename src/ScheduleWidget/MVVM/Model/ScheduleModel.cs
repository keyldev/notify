using ScheduleWidget.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleWidget.MVVM.Model
{
    internal class ScheduleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DayModel> Days { get; set; }

        [NotMapped]
        public RelayCommand LoadScheduleCommand { get; set; }

    }
}
