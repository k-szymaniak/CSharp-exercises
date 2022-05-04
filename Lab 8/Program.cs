using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_8
{
    record Student (int Id, string Name, int Ects);
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 4, 6, 7, 3, 2, 8, 9 };
            IEnumerable<int> evenNumbers =
            from n in ints
            where !(n % 2 == 0) && n > 5
            select n;
            Console.WriteLine(string.Join(", ", evenNumbers));

            IEnumerable<int> test =
            from n in ints
            where n > 5
            select n;
            Console.WriteLine(string.Join(", ", test));
            Predicate<int> intPredicate = n =>
            {
                Console.WriteLine("wywoływanie predykatu dla " + n);
                return n % 2 == 0;
            };
            evenNumbers =
                from n in ints
                where intPredicate.Invoke(n)
                select n;
            evenNumbers =
                from n in evenNumbers
                where n > 5
                select n;
            Console.WriteLine("wywołanie ewaluacji wyrażenia LINQ");
            Console.WriteLine(string.Join(", ", evenNumbers));

            Console.WriteLine(evenNumbers.Max());
            Console.WriteLine(evenNumbers.Min());
            Console.WriteLine(evenNumbers.Count());
            Student[] students =
            {
                new Student(1, "Ewa", 12),
                new Student(2, "Karol", 100),
                new Student(3, "Piotr", 81),
                new Student(4, "Adam", 27),
                new Student(5, "Patryk", 64),
                new Student(6, "Robert", 37),
            };
            IEnumerable<string> enumerable =
            from s in students
            orderby s.Name descending orderby s.Ects
            select s.Name;
            Console.WriteLine(string.Join("\n", enumerable));

            Console.WriteLine(string.Join(", ",
                from i in ints
                orderby i descending orderby i
                select i));
            Console.WriteLine(string.Join(", ", ints.OrderByDescending(i => i)));

            Console.WriteLine(string.Join(", ", students.OrderByDescending(s => s.Name).ThenBy(s => s.Ects)));
            IEnumerable<IGrouping<string, Student>> studentNameGroup =
                from s in students
                group s by s.Name;
            foreach (var item in studentNameGroup)
            {
                Console.WriteLine(item.Key + " " + string.Join(", ", item));
            }
            IEnumerable<(string Key, int)> NameCounters =
            from s in students
            group s by s.Name into groupItem
            select (groupItem.Key, groupItem.Count());
            Console.WriteLine(string.Join(", ", NameCounters));

            string str = "ala ma kota ala lubi koty karol lubi psy";

            //string[] s = str.Split(' ');
            //str =
            //from s in str
            //select (groupItem.Key, groupItem.Count());

            evenNumbers = ints.Where(i => i % 2 == 0).Select(i => i + 2);
            students.Where(s => s.Ects > 20).Select(s => (s.Id, s.Name));

            int[] powerInt =
            Enumerable.Range(0, ints.Length).Select(i => ints[i] * ints[i]).ToArray();
            Console.WriteLine(string.Join(", ", powerInt));

            Random random = new Random();
            random.Next(9999);
            Console.WriteLine(random.Next(11));
            Console.WriteLine(random.Next(11));
            Console.WriteLine(random.Next(11));
            Console.WriteLine(random.Next(11));
            Console.WriteLine(random.Next(11));
            Console.WriteLine(random.Next(11));
            Console.WriteLine(random.Next(11));
            Console.WriteLine(random.Next(11));
            Console.WriteLine(random.Next(11));
            Console.WriteLine(random.Next(11));

        }
    }
}
