<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FakeProductList.ascx.cs" Inherits="Flib.Framework.Web.Spike.FakeUserControls.FakeProductList" %>

<%@ Register TagPrefix="Flib" Namespace="Flib.Framework.Web.Controls" Assembly="Flib.Framework.Web" %>
<%@ Register TagPrefix="Flib" Src="~/FakeUserControls/FakeUILister.ascx" TagName="UILister"%>

        <Flib:FlibRepeater ID="rptRepeater" runat="server" OnItemDataBound="rptRepeater_ItemDataBound" >
            <ItemTemplate>
               <Flib:UILister ID="fkLister" runat="server" />
            </ItemTemplate>
        </Flib:FlibRepeater>