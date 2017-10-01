using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.IEnumerable;

namespace MECS2.Linq
{
    public class LinqExample
    {
        public static void StudentsExampe()
        {
            var students = DataRepo.LoadStudents();

            var singleStudents = from student in students
                                 where student.IsSingle
                                 select student;

            var singleAndOldStudets = from student in students
                                      where student.IsSingle && student.Age > 30
                                      select student;

            singleStudents.Print();
            singleAndOldStudets.Print();

            var studentNames = (from student in students
                                select student.FirstName).ToList<string>();

            studentNames.Print();

            var anonymusObjects = (from student in students
                                   where student.IsSingle
                                   select new { FullName = student.FirstName + " " + student.LastName }).ToList();

            var anonymusObject = new { FullName = "Girshel Megreli" };

            anonymusObjects.Add(anonymusObject);

            anonymusObjects.Print();


            var sortedStudents = from student in students
                                 orderby student.Age descending
                                 select student;

            sortedStudents.Print();

            var grouptedStudents = from student in students
                                   group student by student.IsSingle into stuentsBySingle
                                   where stuentsBySingle.Count() > 1
                                   select new { IsSingle = stuentsBySingle.Key, Count = stuentsBySingle.Count() };

            grouptedStudents.Print();
        }

        public delegate void SomeDelegate(string text);

        public static void Say(string text)
        {
            Console.WriteLine(text);
        }

        public static void DelegateActionFuncLambda()
        {
            var someDelegate = new SomeDelegate(Say);
            someDelegate("GIPA Rocks");

            Action<string> action = delegate (string text)
            {
                Console.WriteLine(text);
            };

            Func<string, int> func = delegate (string text)
            {
                return text.Length;
            };

            action("GIPA ME");
            Console.WriteLine(func("GIPA ME"));

            Action<string> lambdaAction = (text) =>
            {
                Console.WriteLine(text);
            };

            Func<string, int> lambdaFunc = (text) =>
            {
                return text.Length;
            };

            lambdaAction("GIPA ME");
            Console.WriteLine(lambdaFunc("GIPA ME"));
        }

        public static void LinqExamle()
        {
            var students = DataRepo.LoadStudents();
            // https://msdn.microsoft.com/en-us/library/bb394939.aspx#standardqueryops_topic13


            /*
             *  Restriction Operators
             */

            // Where - https://msdn.microsoft.com/en-us/library/bb549418(v=vs.110).aspx
            students.Where(s => s.IsSingle || s.FirstName.ToLower() == "Girshel");
            students.Where((s, index) => s.Age <= index * 10);

            /*
             * Quantifier operators
             */

            // Any - https://msdn.microsoft.com/en-us/library/bb534972(v=vs.110).aspx

            students.Any(s => s.IsSingle);
            students.Any(s => s.Age % 2 == 0);

            // All - https://msdn.microsoft.com/en-us/library/bb548541.aspx

            students.All(s => s.IsSingle == false);

            // Contains - https://msdn.microsoft.com/en-us/library/bb352880.aspx

            var student = new Student() { FirstName = "Girshel", LastName = "Megreli", IsSingle = true, Age = 55 };
            Console.WriteLine(students.Contains(student));

            /*
             * Element Operators
             */

            // First - https://msdn.microsoft.com/en-us/library/bb291976.aspx
            students.First(s => s.Age == 34);

            // FirstOrDefault - https://msdn.microsoft.com/en-us/library/bb340482.aspx
            students.FirstOrDefault(s => s.Age == 34);

            // Last - https://msdn.microsoft.com/en-us/library/bb358775.aspx
            students.Last(s => s.Age == 34);

            // LastOrDefault - https://msdn.microsoft.com/en-us/library/bb301849.aspx
            students.LastOrDefault(s => s.Age == 34);

            // Single - https://msdn.microsoft.com/en-us/library/bb155325.aspx
            students.Last(s => s.Age == 34);

            // SingleOrDefault - https://msdn.microsoft.com/en-us/library/bb342451.aspx
            students.LastOrDefault(s => s.Age == 34);

            // ElementAt - https://msdn.microsoft.com/en-us/library/bb299233.aspx
            students.ElementAt(2);

            // SingleOrDefault - https://msdn.microsoft.com/en-us/library/bb494386.aspx
            students.ElementAtOrDefault(2);


            /*
             * Partitioning operators
             */

            // Take - https://msdn.microsoft.com/en-us/library/bb503062.aspx
            students.Take(5);

            // Skip - https://msdn.microsoft.com/en-us/library/bb358985.aspx
            students.Skip(3).Take(1);

            // TakeWhile - https://msdn.microsoft.com/en-us/library/bb534804.aspx
            students.TakeWhile(s => s.IsSingle);

            // SkipWhile - https://msdn.microsoft.com/en-us/library/bb549075.aspx
            students.SkipWhile(s => s.FirstName.Contains("Gir"));

            /*
             * Generation operators 
             */

            // Range - https://msdn.microsoft.com/en-us/library/system.linq.enumerable.range.aspx
            Enumerable.Range(5, 15);

            // Repeate - https://msdn.microsoft.com/en-us/library/bb348899.aspx
            Enumerable.Repeat(new Student(), 10);

            // Empty - https://msdn.microsoft.com/en-us/library/bb341042.aspx
            Enumerable.Empty<string>();

            // DefaultIfEmpty - https://msdn.microsoft.com/en-us/library/bb360179.aspx
            students.DefaultIfEmpty();

            /*
             * Aggregates4
             */

            // Count - https://msdn.microsoft.com/en-us/library/bb338038.aspx
            students.Count();
            students.Count(s => s.Age < 20);

            // Sum - https://msdn.microsoft.com/en-us/library/bb338442.aspx
            students.Sum(s => s.Age);

            // Average - https://msdn.microsoft.com/en-us/library/bb358946.aspx
            students.Average(s => s.Age);

            // Min - https://msdn.microsoft.com/en-us/library/bb352408.aspx
            students.Min(s => s.FirstName);

            // Max - https://msdn.microsoft.com/en-us/library/bb347632.aspx
            students.Max(s => s.LastName);

            // LongCount - https://msdn.microsoft.com/en-us/library/bb353539.aspx
            students.LongCount();
            students.LongCount(s => s.IsSingle);

            // Aggregate - https://msdn.microsoft.com/en-us/library/bb548651.aspx
            students.Aggregate(0, (initial, next) => initial += next.Age, r => r * r);

            /*
             * Projection 
             */

            students.Select(s => s.Age);
            students.Select(s =>
            {
                return s.Age;
            });

            /*
             * Grouping 
             */

            var nameAndMaxAge = students.GroupBy(s => s.FirstName).Select(s => s.Max(e => e.Age));

            /*
             * Concat 
             */

            students.Concat(new List<Student>()
            {
                new Student() { FirstName = "Name", LastName = "LastName", Age = 100, IsSingle = false }
            });

            /*
            * Ordering 
            */

            students.OrderBy(s => s.FirstName);
            students.OrderByDescending(s => s.LastName);
            students.OrderBy(s => s.Age).ThenByDescending(s => s.FirstName);
            students.Reverse();

            /*
            * Conversion 
            */

            var enumerableStudents = students.AsEnumerable();

            var studentArray = students.ToArray();

            var studentList = students.ToList();

            Dictionary<string, decimal> studentMaxAgePerName = students.
                GroupBy(p => p.FirstName).
                ToDictionary(g => g.Key, g => g.Max(p => (decimal)p.Age));

            /*
            * Cast 
            */

            enumerableStudents.Cast<Student>();
        }
    }
}
