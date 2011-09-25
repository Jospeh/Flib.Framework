using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flib.Framework.Web.Spike.FakePresenters;
using Flib.Framework.Web.Spike.FakeViewModels;
using Flib.Framework.Web.Spike.FakeViews;

namespace Flib.Framework.Web.Spike.ControlSpikes
{
    public partial class FlibRepeaterSpike : FlibPage<ProductPresenter, IFakeProductView>, IFakeProductView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<FakeProductViewModel> data = new List<FakeProductViewModel>();
            data.Add(new FakeProductViewModel(){Price = 20, ProductTitle = "Football"});
            data.Add(new FakeProductViewModel() { Price = 25, ProductTitle = "Jumper" });
            data.Add(new FakeProductViewModel() { Price = 2, ProductTitle = "Basket" });
            data.Add(new FakeProductViewModel() { Price = 23, ProductTitle = "Wine" });
            data.Add(new FakeProductViewModel() { Price = 29, ProductTitle = "Pillow" });

            fkProductList.DataSource = data;
            fkProductList.DataBind();
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            fkProductList.ForEach(i => i.Reload += Reload);
        }

        public void Reload()
        {
            fkProductList.DataSource = null;
            fkProductList.DataBind();
        }



        public string ProductTitle
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int Price
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}