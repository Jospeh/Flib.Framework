using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Flib.Framework.Web.Spike.FakePresenters;
using Flib.Framework.Web.Spike.FakeViews;
using StructureMap;

namespace Flib.Framework.Web.Spike
{
    public abstract class FlibPage<TPresenter, TView> : Page
        where TPresenter : Presenter<TView>
        where TView : IView
    {
        protected TPresenter _presenter;

        public TPresenter Presenter
        {
            set
            {
                _presenter = value;
                _presenter.View = GetView();
            }
        }

        /// <summary>
        /// Gets the view. This will get the page during the ASP.NET
        /// life cycle where the physical page inherits the view
        /// </summary>
        /// <returns></returns>
        private static TView GetView()
        {
            return (TView)HttpContext.Current.Handler;
        }

        protected override void OnPreInit(EventArgs e)
        {
            ObjectFactory.BuildUp(this);
            base.OnPreInit(e);
        }
    }
}