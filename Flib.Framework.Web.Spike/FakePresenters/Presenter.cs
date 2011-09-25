using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flib.Framework.Web.Spike.FakeViews;

namespace Flib.Framework.Web.Spike.FakePresenters
{
    public abstract class Presenter<TView> where TView : IView
    {
        public TView View { get; set; }

        public virtual void OnViewInitialized()
        {
        }

        public virtual void OnViewLoaded()
        {
        }
    }
}