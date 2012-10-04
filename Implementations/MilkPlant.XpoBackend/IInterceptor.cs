using DevExpress.Xpo;

namespace MilkPlant.XpoBackend
{
    public interface IInterceptor<T>
    {
        void BeforeSave(Session session, T instance);
    }
}