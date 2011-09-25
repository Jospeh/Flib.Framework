using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flib.Framework.Util;
using NUnit.Framework;

namespace Flib.Framework.Tests.Util
{
    [TestFixture]
    public class PartialComparerTests
    {
        [Test]
        public void Compare_FirstSecondEqual_ReturnsZero()
        {
            int first = 0;
            int second = 0;

            int? result = PartialComparer.Compare(first, second);
        }
    }
}
