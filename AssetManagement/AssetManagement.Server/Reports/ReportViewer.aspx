<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="LightSwitchApplication.Reports.ReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Viewer</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" ShowCredentialPrompts="False" ShowDocumentMapButton="False" ShowFindControls="False" ShowParameterPrompts="False" ShowPromptAreaButton="False" ShowWaitControlCancelLink="False" SizeToReportContent="True" ZoomMode="PageWidth" ZoomPercent="100" ShowBackButton="False" BackColor="White" DocumentMapCollapsed="False"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
