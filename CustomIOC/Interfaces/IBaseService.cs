namespace CustomIOC.Interfaces
{
    public interface IBaseService<T> where T : class 
    {
        void Start();
        void End();
    }
}