<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FakeUILister.ascx.cs" Inherits="Flib.Framework.Web.Spike.FakeUserControls.FakeUILister" %>
<li>
    <asp:literal ID="lblProductTitle" runat="server" /><asp:Literal ID="lblPrice" runat="server" />
</li>

<asp:LinkButton ID="lnkReload" runat="server" Text="Reload"  OnClick="lnkReload_Click"/>