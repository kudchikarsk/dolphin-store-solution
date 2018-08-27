using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using StructureMap;

namespace WebAPI
{
    internal class StructureMapDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IContainer container;

        public StructureMapDependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new StructureMapDependencyResolver(container.GetNestedContainer());
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.GetInstance(serviceType);
            }
            catch (StructureMapException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.GetAllInstances(serviceType) as IEnumerable<object>;
            }
            catch (StructureMapException)
            {
                return null;
            }
        }
    }
}