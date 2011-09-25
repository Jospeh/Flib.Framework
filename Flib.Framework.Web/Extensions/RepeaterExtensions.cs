using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flib.Framework.Web.Extensions
{
    public static class RepeaterExtensions
    {
        public static IEnumerable<T> GetControlsOfType<T>(this Repeater repeater) where T: class
        {
            foreach (RepeaterItem item in repeater.Items)
            {
                foreach (Control control in item.Controls)
                {
                    Repeater nestedRepeater = control as Repeater;
                    if (nestedRepeater != null)
                    {
                        foreach (T nestedControl in nestedRepeater.GetControlsOfType<T>())
                        {
                            yield return nestedControl;
                        }
                    }

                    T t = control as T;
                    if (t != null)
                    {
                        yield return t;
                    }
                }
            }
        }
        public static void ForEach<TControl>(this Repeater repeater, Action<TControl> action) where TControl : Control
        {
            foreach (RepeaterItem item in repeater.Items)
            {
                foreach (Control control in item.Controls)
                {
                    Repeater nestedRepeater = control as Repeater;
                    if(nestedRepeater != null)
                    {
                        nestedRepeater.ForEach(action);
                    }

                    TControl t = control as TControl;
                    if(t != null)
                    {
                        action(t);
                    }
                }
            }
        }

        public static void ForEachItem<T>(this Repeater repeater, Action<T> action) where T : class
        {
            repeater.ForEachNestedRepeater(action);

            foreach (T t in repeater.GetItemsOfType<T>())
            {
                action(t);
            }

        }

        private static void ForEachNestedRepeater<T>(this Repeater repeater, Action<T> action) where T : class 
        {
            repeater.GetItemsOfType<Repeater>()
                    .ForEach(r => r.ForEachItem(action));
        }

        private static IEnumerable<T> GetItemsOfType<T>(this Repeater repeater)
        {
            return repeater.Items.Cast<RepeaterItem>()
                                 .Select(item => item.Controls)
                                 .OfType<T>();
        }

        private static void ForEach(this IEnumerable<Repeater> repeaters, Action<Repeater> action)
        {
            foreach (var repeater in repeaters)
            {
                action(repeater);
            }
        }
    }
}
