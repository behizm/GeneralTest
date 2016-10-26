namespace CustomIOC.Models
{
    public class Person
    {
        public Person()
        {
        }


        public Person(int id, string firstname, string lastname, int age)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Age = age;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}