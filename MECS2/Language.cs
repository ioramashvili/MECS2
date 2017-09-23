using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECS2
{
    class Language: IComparable<Language>
    {
        public string Name { get; set; }
        public int Position { get; set; }

        public override string ToString()
        {
            return "Language = " + Name + ", Position = " + Position;
        }

        private static void PrintLanguages(List<Language> languages)
        {
            foreach (var language in languages)
            {
                Console.WriteLine(language);
            }
        }

        public static void PrintExample()
        {
            List<Language> languages = new List<Language>()
            {
                new Language() { Name = "Swift", Position = 4 },
                new Language() { Name = "C#", Position = 1 },
                new Language() { Name = "Kotlin", Position = 10 }
            };

            var reverseLanguageComparer = new ReverseLanguageComparer();

            languages.Sort(reverseLanguageComparer);

            Console.WriteLine("Sorted List");
            PrintLanguages(languages);
            Console.WriteLine();

            var newLanguage = new Language() { Name = "Swift", Position = 8 };

            var index = languages.BinarySearch(newLanguage, reverseLanguageComparer);

            if (index < 0)
            {
                languages.Insert(~index, newLanguage);
                Console.WriteLine("New Language added on index ", ~index);
            } else
            {
                Console.WriteLine("Searched index is ", index);
                Console.WriteLine(languages[index]);
            }

            Console.WriteLine();
            Console.WriteLine("Latest List");
            PrintLanguages(languages);
        }

        public int CompareTo(Language other)
        {
            var positionCompare = Position.CompareTo(other.Position);

            if (positionCompare == 0)
            {
                return Name.CompareTo(other.Name);
            }

            return positionCompare;
        }
    }

    class ReverseLanguageComparer : IComparer<Language>
    {
        public int Compare(Language x, Language y)
        {
            var nameCompare = x.Name.CompareTo(y.Name);

            if (nameCompare == 0)
            {
                return x.Position.CompareTo(y.Position);
            }

            return nameCompare;
        }
    }
}
