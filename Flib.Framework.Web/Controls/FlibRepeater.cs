using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flib.Framework.Web.Controls
{
    public class FlibRepeater : Repeater
    {
        public void ForEach<T>(Action<T> action) where T : class
        {
            var itemsOfT = Items.Cast<RepeaterItem>().Select(item => item.Controls).OfType<T>();
            
            foreach (T t in itemsOfT)
            {
                action(t);
            }
        }
    }
}
