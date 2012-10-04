using System;
using System.Collections.Generic;
using System.Reflection;
using DevExpress.Xpo;
using MilkPlant.Interfaces;
using System.Linq;
using MilkPlant.Interfaces.Models.Base;
using Omu.ValueInjecter;

namespace MilkPlant.XpoBackend
{
    public class Repository : IRepository
    {
        private readonly DataContext context = new DataContext();
        private readonly IList<Type> models;

        public Repository()
        {
            models = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.Namespace != null && x.Namespace.Contains("Models")).ToList();
        }
        
        public void Save<T>(T instance) where T : Identifiable
        {
            using (var session = context.GetSession())
            {
                var interceptorType = typeof (IInterceptor<>).MakeGenericType(GetStorageModelType<T>());
                var interceptorImplType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => interceptorType.IsAssignableFrom(x) &&
                                         !x.IsInterface &&
                                         !x.IsAbstract);

                var storageModel = GetStorageModel(instance);

                if (interceptorImplType != null)
                {
                    var interceptor = Activator.CreateInstance(interceptorImplType);
                    interceptorImplType.GetMethod("BeforeSave").Invoke(interceptor, new[] {session, storageModel});
                }
                
                session.Save(storageModel);
            }
        }

        public IEnumerable<T> GetAll<T>() where T : Identifiable
        {
            using (var session = context.GetSession())
            {
                var queryType = typeof (XPQuery<>).MakeGenericType(GetStorageModelType<T>());
                return ((IQueryable) Activator.CreateInstance(queryType, session))
                    .Cast<object>()
                    .Select(x => Activator.CreateInstance<T>().InjectFrom(x))
                    .Cast<T>()
                    .ToList();
            }
        }

        private Type GetStorageModelType<TNativeModel>() where TNativeModel : Identifiable
        {
            return models.First(x => x.Name == typeof (TNativeModel).Name);
        }

        private object GetStorageModel<TNativeModel>(TNativeModel instance) where TNativeModel : Identifiable
        {
            return Activator.CreateInstance(GetStorageModelType<TNativeModel>()).InjectFrom(instance);
        }
    }
}