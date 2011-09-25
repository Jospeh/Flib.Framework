using System;
using Flib.Framework.Web.MVP;
using Moq;

namespace Flib.Framework.Tests.Web
{
    public class BasePresenterFixture<TView, TPresenter>
        where TView : class, IView
        where TPresenter : class
    {
        protected Mock<TView> MockView { get; set; }

        private object[] _presenterArgs;
        /// <summary>
        /// Is set in Fixture Setup by default to contain the View
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OverridePresenterArgs(params object[] args)
        {
            _presenterArgs = args;
        }

        public void Setup()
        {
            MockView = new Mock<TView>();
            OverridePresenterArgs(View);
        }

        protected TView View
        {
            get
            {
                return MockView.Object;
            }
        }

        protected TPresenter Presenter
        {
            get { return (TPresenter)Activator.CreateInstance(typeof(TPresenter), _presenterArgs); }
        }
    }
}
