using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flib.Framework.Web.Spike.FakeViews;

namespace Flib.Framework.Web.Spike.FakeUserControls
{
    public partial class FakeUILister : UserControl, IFakeProductView 
    {
        public Action Reload { get; set; }
        public string ProductTitle
        {
            get { return lblProductTitle.Text; }
            set { lblProductTitle.Text = value; }
        }

        public int Price
        {
            get { return Convert.ToInt32(lblPrice.Text); }
            set { lblPrice.Text = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkReload_Click(object sender, EventArgs e)
        {
            if(Reload != null)
            {
                Reload();
            }
        }
    }
}