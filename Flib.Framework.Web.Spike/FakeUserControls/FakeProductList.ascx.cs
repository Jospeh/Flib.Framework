using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flib.Framework.Web.Extensions;
using Flib.Framework.Web.Spike.FakeViewModels;

namespace Flib.Framework.Web.Spike.FakeUserControls
{
    public partial class FakeProductList : System.Web.UI.UserControl
    {
        public List<FakeProductViewModel> DataSource
        {
            get { return (List<FakeProductViewModel>) rptRepeater.DataSource; }
            set { rptRepeater.DataSource = value; }
        }

        public Action<Action<FakeUILister>> ForEach;

        protected void Page_Load(object sender, EventArgs e)
        {
            ForEach = rptRepeater.ForEach;
        }

        public Action Reload { get; set; }

        protected void rptRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item)
            {
                FakeProductViewModel viewModel = (FakeProductViewModel)e.Item.DataItem;
                FakeUILister fkLister = (FakeUILister) e.Item.FindControl("fkLister");

                fkLister.ProductTitle = viewModel.ProductTitle;
                fkLister.Price = viewModel.Price;

                Reload += fkLister.Reload;
            }
        }

        public override void DataBind()
        {
            rptRepeater.DataBind();
        }
    }
}