using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;

         }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw InvalidOperationException("Zu wenig Studenten");
            }

            var treshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[treshold - 1] <= averageGrade)
                return 'A';
            else if (grades[treshold * 2 - 1] <= averageGrade)
                return 'B';
            else if (grades[treshold * 3 - 1] <= averageGrade)
                return 'C';
            else if (grades[treshold * 4 - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }



        private Exception InvalidOperationException(string v)
        {
            throw new NotImplementedException();
        }
    }
}
