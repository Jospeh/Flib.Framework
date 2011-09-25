using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flib.Framework.Web.Spike.FakePresenters;
using Flib.Framework.Web.Spike.FakeViews;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Flib.Framework.Web.Spike
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<ControllerRegistry>());
        }
    }

    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            //Presenter Views
            Scan(p => p.AddAllTypesOf(typeof(Presenter<IView>)));
        }
    }
}