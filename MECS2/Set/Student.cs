using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS2.Set
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Student;

            if (other == null)
            {
                return false;
            }

            return Name == other.Name && Age == other.Age;
        }

        private static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var stuent in students)
            {
                Console.WriteLine(stuent);
            }
        }

        public override string ToString()
        {
            return Name + ", " + Age + " " + GetHashCode();
        }

        public static void PrintExample()
        {
            HashSet<Student> students = new HashSet<Student>()
            {
                new Student() { Name = "Girshel", Age = 24 },
                new Student() { Name = "Mamuka", Age = 25 },
                new Student() { Name = "Zuri", Age = 26 }
            };

            var newStudent = new Student() { Name = "Zuri", Age = 26 };

            students.Add(newStudent);

            PrintStudents(students);
            
            // Fast searching and removing than List
            var containsNewStudent = students.Contains(newStudent);

            if (containsNewStudent)
            {
                Console.WriteLine("Yeeeees");
            }
        }
    }
}
