using System.Collections.Generic;

namespace CustomIOC.Models
{
    public class Context : IContext
    {
        public List<Person> Persons { get; set; } = new List<Person>
        {
            new Person(1, "behi", "zei", 30),
            new Person(2, "behnam", "zeighami", 32),
            new Person(3, "sadra", "babaie", 28),
        };

        public List<Student> Students { get; set; } = new List<Student>
        {
            new Student(1, 1, "A", 17.5),
            new Student(2, 2, "B", 18.25),
            new Student(3, 3, "A", 18),
        };
    }

    public interface IContext
    {
        List<Person> Persons { get; set; }
        List<Student> Students { get; set; }
    }
}