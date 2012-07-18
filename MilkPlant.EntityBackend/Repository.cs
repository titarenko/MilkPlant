using System.Data;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models.Base;

namespace MilkPlant.EntityBackend
{
    public class Repository : IRepository
    {
        private readonly DataContext context = new DataContext();

        public void Save<T>(T instance) where T : Identifiable
        {
            if (instance.Id == default(int))
            {
                context.Set<T>().Add(instance);
            }
            else
            {
                context.Entry(instance).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}