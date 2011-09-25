<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlibRepeaterSpike.aspx.cs" Inherits="Flib.Framework.Web.Spike.ControlSpikes.FlibRepeaterSpike" %>
<%@ Register  TagPrefix="Flib" Namespace="Flib.Framework.Web.Controls"  Assembly="Flib.Framework.Web" %>
<%@ Register TagPrefix="Flib" TagName="FakeProductList" Src="~/FakeUserControls/FakeProductList.ascx" %>
<%@ Register TagPrefix="Flib" Namespace="Flib.Framework.Web.Spike.FakeUserControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <Flib:FakeProductList ID="fkProductList" runat="server" />

        

    
    </div>
    </form>
</body>
</html>
