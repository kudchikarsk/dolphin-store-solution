using StructureMap;
using System;

namespace WebAPI
{
    internal class IOC
    {
        internal static Container Initialize()
        {
            var container = new Container();
            container.Configure(config=> config.AddRegistry(new HandleRegistry()));
            return container;
        }
    }
}