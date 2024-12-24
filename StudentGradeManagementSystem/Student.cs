using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeManagementSystem
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private List<string> className = new List<string>();
        private List<int> grades = new List<int>();

        /// <summary>
        /// Student Constructor
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <param name="name">Student Name</param>
        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name; 
        }

        /// <summary>
        /// Averages the students grades or returns No Grades as string.
        /// </summary>
        /// <returns>Returns Grade Average or No Grades as a String</returns>
        public string AverageGrade()
        {
            if (grades.Any())
                return grades.Average().ToString();
            else
                return "No Grades";
        }

        /// <summary>
        /// Gets all the class names and grades as a string on new lines and returns it.
        /// </summary>
        /// <returns>Returns string with the following on each line: className | grade</returns>
        public string GetGrades()
        {
            string str = "";
            for(int i = 0; i < className.Count; i++)
            {
                str += $"{className[i]}\t| {grades[i]}\n";
            }
            return str;
        }

        /// <summary>
        /// Add a new grade to the student into their respected list.
        /// </summary>
        /// <param name="className">Class Name for list</param>
        /// <param name="grade">Grade for list</param>
        public void AddGrade(string className, int grade)
        {
            this.className.Add(className);
            grades.Add(grade);

        }

        /// <summary>
        /// Override to return all data about user including grade average.
        /// </summary>
        /// <returns>Student's data and average</returns>
        public override string ToString()
        {
            string output = $"ID: {Id} - Name: {Name}";

            if (className.Any())
            {
                for (int i = 0; i < className.Count; i++)
                {
                    output += $"\n - {className[i]}: {grades[i]}";
                }

                output += $"\n = Average Grade: {AverageGrade()}";
            }
            return output;
        }
    }
}
