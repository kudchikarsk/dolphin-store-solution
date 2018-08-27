using DA.ClientManagement.Data;
using DA.SharedKernel.Interfaces;
using DA.StockManagement.Data;
using DA.TonerJobManagement.Data;
using StructureMap;

namespace WebAPI
{
    public class HandleRegistry : Registry
    {
        public HandleRegistry()
        {
            Scan(x=> {
                x.TheCallingAssembly();
                x.AssemblyContainingType<StockContext>();
                x.AssemblyContainingType<ClientContext>();
                x.AssemblyContainingType<TonerJobContext>();
                x.WithDefaultConventions();
                x.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
                x.ConnectImplementationsToTypesClosing(typeof(IHandle<>));
            });
        }
    }
}