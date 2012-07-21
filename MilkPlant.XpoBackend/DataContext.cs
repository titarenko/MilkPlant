using System.Reflection;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using MilkPlant.Interfaces;
using System.Linq;

namespace MilkPlant.XpoBackend
{
    public class DataContext
    {
        public DataContext()
        {
            if (XpoDefault.DataLayer == null)
            {
                var connectionString = MSSqlConnectionProvider.GetConnectionString(
                    @".\SQLEXPRESS", typeof (DataContext).FullName);
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                    connectionString, AutoCreateOption.DatabaseAndSchema);
                EnableModelPersistence(XpoDefault.DataLayer.Dictionary);
            }
        }

        private void EnableModelPersistence(XPDictionary dictionary)
        {
            var infos = dictionary.CollectClassInfos(true, Assembly.GetAssembly(typeof (IRepository)));
            foreach (var info in infos.Where(x => x.ClassType.Namespace.EndsWith("Models")))
            {
                info.AddAttribute(new PersistentAttribute());
                info.GetMember("Id").AddAttribute(new KeyAttribute(true));
                dictionary.AddClassInfo(info);
            }
        }

        public Session GetSession()
        {
            return new Session();
        }
    }
}