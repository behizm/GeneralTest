using System;
using System.Linq;
using CustomIOC.Interfaces;
using CustomIOC.Models;

namespace CustomIOC.Services
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        private readonly IContext _context;

        public PersonService(IContext context)
        {
            this._context = context;
        }

        public void WriteName(int id)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"Name is {person.FirstName} {person.LastName}");
        }

        public void WriteAge(int id)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"age : {person.Age}");
        }
    }
}