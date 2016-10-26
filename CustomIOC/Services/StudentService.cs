using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomIOC.Interfaces;
using CustomIOC.Models;

namespace CustomIOC.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IContext _context;
        private readonly IPersonService _personService;

        public StudentService(IContext context, IPersonService personService)
        {
            _context = context;
            _personService = personService;
        }

        public void WriteInfo(int id)
        {
            _personService.WriteName(id);
            _personService.WriteAge(id);
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"Average : {student.Average}");
            Console.WriteLine($"In class {student.ClassName}");
        }
    }
}
