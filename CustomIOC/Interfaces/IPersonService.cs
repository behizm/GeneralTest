using CustomIOC.Models;

namespace CustomIOC.Interfaces
{
    public interface IPersonService : IBaseService<Person>
    {
        void WriteName(int id);
        void WriteAge(int id);
    }
}