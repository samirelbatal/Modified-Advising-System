<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentviewUpcomingInstallment.aspx.cs" Inherits="Modified_Advising_System.StudentviewUpcomingInstallment" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upcoming Installment</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: #999;
            margin: 0;
        }

        #form1 {
            text-align: center;
            padding-top: 20px;
            position: relative;
        }

        #Label2 {
            font-size: 28px;
            font-weight: bold;
            color: #fff;
        }

        .dashboard-button {
            background-color: #e74c3c;
            color: white;
            padding: 8px 16px;
            font-size: 14px;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease;
            position: absolute;
            top: 10px;
            left: 10px;
        }

        .dashboard-button:hover {
            background-color: #c0392b;
        }

        .installment-container {
            margin-top: 20px;
            padding: 10px;
            background-color: #3498db;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            display: inline-block;
        }

        .installment-deadline {
            color: #fff;
            font-size: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="ReturnHomeButton_Click" Text="Return to Dashboard" CssClass="dashboard-button" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Upcoming Installment"></asp:Label>
       <br />
        <div class="installment-container">
            <asp:Label ID="lblResult" runat="server" CssClass="installment-deadline"></asp:Label>
        </div>
    </form>
</body>
</html>