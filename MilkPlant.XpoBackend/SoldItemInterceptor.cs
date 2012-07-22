using DevExpress.Xpo;
using MilkPlant.XpoBackend.Models;

namespace MilkPlant.XpoBackend
{
    public class SoldItemInterceptor : IInterceptor<SoldItem>
    {
        public void BeforeSave(Session session, SoldItem instance)
        {
            instance.Distributor = session.GetObjectByKey<Distributor>(instance.DistributorId);
            instance.Product = session.GetObjectByKey<Product>(instance.ProductId);
        }
    }
}