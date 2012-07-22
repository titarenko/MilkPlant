using DevExpress.Xpo;
using DevExpress.Xpo.DB;

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
            }
        }

        public Session GetSession()
        {
            return new Session();
        }
    }
}