using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Common.IEnumerable;

namespace MECS2.IO
{
    public class IOExample
    {

        //https://jsonplaceholder.typicode.com/users

        public static void Start()
        {
            var currentDict = Directory.GetCurrentDirectory();
            DirectoryInfo info = new DirectoryInfo(currentDict);
            var files = info.GetFiles();

            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }

            var directories = info.GetDirectories();

            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }

            var fileName = Path.Combine(info.FullName, @"IO\data.txt");
            var fileInfo = new FileInfo(fileName);

            if (fileInfo.Exists)
            {
                using (var streamReader = new StreamReader(fileName))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }

            var jsonFileName = Path.Combine(info.FullName, @"IO\users.json");
            DeserializeUsers(jsonFileName).Print();
        }

        public static List<string[]> ReadLines(string fileName)
        {
            var results = new List<string[]>();

            using (var reader = new StreamReader(fileName))
            {
                while (reader.Peek() > -1)
                {
                    var lines = reader.ReadLine().Split(',');
                    results.Add(lines);
                }

                //var line = "";
                //while ((line = reader.ReadLine()) != null)
                //{
                //    var lines = line.Split(',');
                //    results.Add(lines);
                //}
            }

            return results;
        }

        public static List<User> DeserializeUsers(string fileName)
        {
            var users = new List<User>();
            var serializer = new JsonSerializer();

            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                users = serializer.Deserialize<List<User>>(jsonReader);
            }
            
            return users;
        }
    }
}
