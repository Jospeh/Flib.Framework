using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flib.Framework.Util
{
    public static class ExtensionsT
    {
        public static TResult GetValueOrDefault<TTarget, TResult>(this TTarget target, Func<TTarget, TResult> getValue) where TTarget : class
        {
            return target == null ? default(TResult) : getValue(target);
        }

        public static TResult IsNull<TTarget, TResult>(this TTarget target, Func<TTarget, TResult> getValue, TResult replacementValue) where TTarget : class
        {
            return target == null ? replacementValue : getValue(target);
        }

        public static TResult Get<TTarget, TResult>(this TTarget target, Func<TTarget, TResult> getValue) where TTarget : class
        {
            return target.GetValueOrDefault(getValue);
        }

        public static TResult Or<TResult>(this TResult target, TResult replacement)
        {
            return Equals(target, default(TResult)) ? replacement : target;
        }
    }
}
