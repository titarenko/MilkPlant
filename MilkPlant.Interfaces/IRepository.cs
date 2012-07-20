using System.Collections.Generic;
using MilkPlant.Interfaces.Models.Base;

namespace MilkPlant.Interfaces
{
    public interface IRepository
    {
        void Save<T>(T instance) where T : Identifiable;
        IEnumerable<T> GetAll<T>() where T : Identifiable;
    }
}