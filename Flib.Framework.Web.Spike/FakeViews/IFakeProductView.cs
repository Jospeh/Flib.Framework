namespace Flib.Framework.Web.Spike.FakeViews
{
    public interface IFakeProductView : IView
    {
        string ProductTitle { get; set; }
        int Price { get; set; }
    }
}
