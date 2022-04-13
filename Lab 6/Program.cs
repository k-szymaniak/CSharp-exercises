using System;
using System.Collections.Generic;

namespace Lab_6
{
    public class Student: IComparable<Student>
    {
        public string Name { get; set; }
        public int Ects { get; set; }

        public int CompareTo(Student other)
        {
            if (Name.CompareTo(other.Name) == 0)
            {
                return Ects.CompareTo(other.Ects);
            }

            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            Console.WriteLine("Student Equals");
            return obj is Student student &&
                   Name == student.Name &&
                   Ects == student.Ects;
        }

        public override int GetHashCode()
        {
            Console.WriteLine("Student HashCode");
            return HashCode.Combine(Name, Ects);
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("Ewa");
            names.Add("Adam");
            names.Add("Karol");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine(names.Contains("Adam"));

            ICollection<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Adam", Ects = 10 });
            students.Add(new Student() { Name = "Karol", Ects = 50 });
            students.Add(new Student() { Name = "Kinga", Ects = 60 });
            students.Remove(new Student() { Name = "Adam", Ects = 10 });

            foreach (Student name in students)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }
            Console.WriteLine(students.Contains(new Student() { Name = "Adam", Ects = 17 }));
            List<Student> list = (List<Student>)students;
            Console.WriteLine(list[0]);
            list.Insert(1, new Student() { Name = "Patryk", Ects = 80 });
            foreach (Student name in students)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }
            int index = list.IndexOf(new Student() { Name = "Karol", Ects = 50 });
            list.RemoveAt(index);
            Console.WriteLine("-----------------------SET------------------------");
            ISet<string> set = new HashSet<string>();
            set.Add("Adam");
            set.Add("Karol");
            set.Add("Kinga");
            foreach (string name in set)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("-----------------------SET------------------------");
            ISet<Student> studentGroup = new HashSet<Student>();
            studentGroup.Add(new Student() { Name = "Adam", Ects = 10 });
            studentGroup.Add(new Student() { Name = "Karol", Ects = 50 });
            studentGroup.Add(new Student() { Name = "Kinga", Ects = 60 });
            studentGroup.Add(new Student() { Name = "Kinga", Ects = 60 });

            foreach (Student name in studentGroup)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }
            studentGroup.Contains(new Student() { Name = "Adam", Ects = 10 });


            studentGroup = new SortedSet<Student>(studentGroup);
            studentGroup.Add(new Student() { Name = "Kinga", Ects = 60 });
            studentGroup.Add(new Student() { Name = "Kinga", Ects = 20 });
            foreach (Student name in studentGroup)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }

            studentGroup.Contains(new Student() { Name = "Adam", Ects = 10 });
            Console.WriteLine("========================================================");
            Dictionary<Student, string> phonebook = new Dictionary<Student, string>();
            phonebook[list[0]] = "960390363";
            phonebook[list[0]] = "460390363";
            phonebook[list[0]] = "760390363";
            Console.WriteLine(phonebook.Keys);
            if (phonebook.ContainsKey(new Student() { Name = "Ewa", Ects = 12 }))
            {
                Console.WriteLine("Jest telefon");
            }
            else
            {
                Console.WriteLine("Brak telefonu");
            }
            foreach (var item in phonebook)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            string[] arr = { "Adam", "Ewa", "Karol", "Robert", "Ewa", "Adam" };
            Dictionary<string, int> counters = new Dictionary<string, int>();
            foreach(string name in arr)
            {
                if (counters.ContainsKey(name))
                {
                    counters[name] += 1;
                }
                else
                {
                    counters.Add(name, 1);
                }
            foreach(var item in counters)
                {
                    Console.WriteLine(item.Key + " wystepuje " + item.Value);
                }
            }
        }
    }
}
