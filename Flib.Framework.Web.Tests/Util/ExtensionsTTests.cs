using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Flib.Framework.Util;

namespace Flib.Framework.Web.Tests.Util
{
    [TestFixture]
    public class ExtensionsTTests
    {

        [Test]
        public void IsNull_TargetIsNull_ReturnsReplacementValue()
        {
            object target = null;
            object result = target.IsNull(o => o.ToString(), "Passed");
            Assert.AreEqual(result, "Passed");
        }

        [Test]
        public void IsNull_TargetNotNull_ReturnsSpecifiedValueOnTarget()
        {
            TestTarget target = new TestTarget();
            string result = target.IsNull(o => o.StringOnTarget, "StringOnTarget should be returned");
            Assert.AreEqual(result, "StringOnTarget");
        }

        [Test]
        public void GetValueOrDefault_TargetIsNull_ReturnsDefaultValue()
        {
            TestTarget target = null;

            string result = target.GetValueOrDefault(t => t.StringOnTarget);

            Assert.AreEqual(result, default(string));
        }

        [Test]
        public void GetOrFluent_TargetNull_OrReturnsReplacement()
        {
            TestTarget target = null;

            string result = target.Get(t => t.StringOnTarget).Or("replacement");

            Assert.AreEqual(result, "replacement");
        }

        [Test]
        public void GetOrFluent_TargetNotNull_OrReturnsValue()
        {
            TestTarget target = new TestTarget();

            string result = target.Get(t => t.StringOnTarget).Or("StringOnTarget should be returned");

            Assert.AreEqual(result, "StringOnTarget");
        }
    }

    public class TestTarget
    {
        public string StringOnTarget { get { return "StringOnTarget"; } }
        public int IntOnTarget { get { return 1; } }
    }
}
