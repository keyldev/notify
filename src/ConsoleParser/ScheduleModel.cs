namespace ConsoleParser
{
    internal class ScheduleModel
    {

        public string? DayOfWeek { get; set; }
        public int LessonNumber { get; set; }
        public string? LessonType { get; set; }
        public string? LessonName { get; set; }
        public string? LessonTeacher { get; set; }
        public string? LessonRoom { get; set; }
        public string? StudentGroup { get; set; }

        public int LessonTime { get; set; }

    }
}
