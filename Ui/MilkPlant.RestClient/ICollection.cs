using System.Collections.Generic;

namespace MilkPlant.RestClient
{
    public interface ICollection<T>
    {
        void Save(T instance);
        IEnumerable<T> GetAll();
    }
}