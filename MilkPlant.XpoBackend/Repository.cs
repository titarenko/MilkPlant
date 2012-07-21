using System.Collections.Generic;
using DevExpress.Xpo;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models.Base;
using System.Linq;

namespace MilkPlant.XpoBackend
{
    public class Repository : IRepository
    {
        private readonly DataContext context = new DataContext();

        public void Save<T>(T instance) where T : Identifiable
        {
            using (var session = context.GetSession())
            {
                session.Save(instance);
            }
        }

        public IEnumerable<T> GetAll<T>() where T : Identifiable
        {
            using (var session = context.GetSession())
            {
                return new XPCollection<T>(session, false).ToList();
            }
        }
    }
}