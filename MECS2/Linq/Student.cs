using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS2.Linq
{
    class Student: IEquatable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsSingle { get; set; }

        public override string ToString()
        {
            return $"FullName {FirstName + " " + LastName }, Age {Age}, IsSingle {IsSingle}";
        }

        public bool Equals(Student other)
        {
            return FirstName == other.FirstName && LastName == other.LastName;
        }
    }
}
