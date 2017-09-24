using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS2.Linq
{
    class DataRepo
    {
        public static List<Student> LoadStudents()
        {
            return new List<Student>
            {
                new Student() { FirstName = "Bob", LastName = "Bob", Age = 25, IsSingle = false },
                new Student() { FirstName = "Joy", LastName = "Joy1", Age = 23, IsSingle = true },
                new Student() { FirstName = "George", LastName = "George1", Age = 21, IsSingle = false },
                new Student() { FirstName = "Nick", LastName = "Nick1", Age = 40, IsSingle = true },
                new Student() { FirstName = "Girshel", LastName = "Megreli", Age = 33, IsSingle = false }
            };
        }
    }
}
