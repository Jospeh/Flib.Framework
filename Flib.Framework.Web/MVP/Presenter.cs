using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flib.Framework.Web.MVP
{
    public abstract class Presenter<TView>
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
