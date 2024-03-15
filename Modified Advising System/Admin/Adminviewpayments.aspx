<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adminviewpayments.aspx.cs" Inherits="Modified_Advising_System.Adminviewpayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
            <style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        background-color: #f5f5f5;
        margin: 0;
        padding: 0;
    }

    #form1 {
        text-align: center;
        margin-top: 50px;
    }

    #viewpaymentPanel {
        width: 70%;
        margin: 0 auto;
    }

        #paymentLabel {
    font-size: 32px;
    font-weight: bold;
    margin-bottom: 20px;
}


    .dashboard-button {
        padding: 12px 20px;
        font-size: 16px;
        background-color: #3498db; /* Blue color */
        color: #fff;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    .dashboard-button:hover {
        background-color: #2980b9;
    }

    .output-table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    .output-table th, .output-table td {
        border: 1px solid #ddd;
        padding: 10px;
        text-align: left;
    }

    .output-table th {
        background-color: cadetblue; 
        color: #fff;
    }

    .message {
        color: red;
        font-size: 24px;
        font-weight: bold;
        margin-top: 20px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="paymentLabel" runat="server" Text="Payment Details"></asp:Label>
             <br/>
            <br/>
               <asp:Panel ID="viewpaymentPanel" runat="server" CssClass="output-table">
                         <asp:Literal ID="viewpaymentlist" runat="server"></asp:Literal>
                </asp:Panel>
            <br/>
            <br/>
            <asp:Button ID="Button1" runat="server" OnClick="back" Text="Go Back To Dashboard" CssClass="dashboard-button" />
            
        </div>
    </form>
</body>
</html>
