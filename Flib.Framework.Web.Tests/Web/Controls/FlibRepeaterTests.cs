using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flib.Framework.Web.Controls;
using Flib.Framework.Web.Extensions;
using NUnit.Framework;

namespace Flib.Framework.Tests.Web.Controls
{
    [TestFixture]
    public class FlibRepeaterTests
    {
        private FlibRepeater _repeater;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _repeater = new FlibRepeater();
            _repeater.DataSource = FakeUserControlWithList.GetDataSource();
            _repeater.Items[0].Controls.Add(new FakeUserControlWithList());
            _repeater.Controls.Add(new FakeUserControlWithList());
        }

        [Test]
        public void ForEach_AddingItemToAListInTheRepeaterItems_EachListContainsNewItem()
        {
            //Act
            _repeater.ForEach<FakeUserControlWithList>(f => f.FakeList.Add("FakeString"));

            //Assert
            var repeaterItems = _repeater.Items.Cast<RepeaterItem>();
            var controls = repeaterItems.Select(item => item.Controls).OfType<FakeUserControlWithList>();
            foreach (var fakeUserControlWithList in controls)
            {
                Assert.AreEqual(1, fakeUserControlWithList.FakeList.Count);
            }
        }

        [Test]
        public void GetControlsOfType_Iterator_YieldReturnsItems()
        {
            int controlCount = 0;

            foreach (var control in _repeater.GetControlsOfType<FakeUserControlWithList>())
            {
                controlCount++;
            }

            Assert.AreEqual(2, controlCount);
        }
    }

    public class FakeUserControlWithList : UserControl
    {
        public List<string> FakeList = new List<string>();

        public static IList<FakeUserControlWithList> GetDataSource()
        {
            return new List<FakeUserControlWithList>()
                       {
                           new FakeUserControlWithList(),
                           new FakeUserControlWithList()
                       };
        }
    }
}
