namespace MilkPlant.Interfaces
{
    public interface IRepository
    {
        void Save<T>(T instance);
    }
}