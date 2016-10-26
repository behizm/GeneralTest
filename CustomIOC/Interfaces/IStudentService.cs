using CustomIOC.Models;

namespace CustomIOC.Interfaces
{
    public interface IStudentService : IBaseService<Student>
    {
        void WriteInfo(int id);
    }
}