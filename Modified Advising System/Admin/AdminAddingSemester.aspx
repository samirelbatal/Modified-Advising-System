<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAddingSemester.aspx.cs" Inherits="Modified_Advising_System.AdminAddingSemester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        #form1 {
            max-width: 600px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        #form1 h2 {
            text-align: center;
            color: #333;
        }

        #form1 div {
            margin-bottom: 10px;
        }

        .select {
            width: calc(100% - 16px);
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        #btnAdd {
            padding: 16px;
            background-color: #337ab7;
            color: #fff;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            transition: background-color 0.3s ease;
            margin-top: 20px;
            width: 50%;
            box-sizing: border-box;
            font-size: 30px;
        }

        #btnAdd:hover {
            background-color: #2e6da4;
        }

        #btnBack {
            padding: 12px;
            background-color: red;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
            transition: background-color 0.3s ease;
            width: 20%;
            box-sizing: border-box;
            margin-top: 15px;
        }

        #btnBack:hover {
            background-color: #333;
        }

        #lblMessage {
            margin-top: 10px;
            display: block;
            color: #5cb85c; /* Success color */
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Adding Semester</h2>
            <div>Semester Start Date</div>
            <asp:TextBox ID="Start" runat="server" type="date" CssClass="select"></asp:TextBox>

            <div>Semester End Date</div>
            <asp:TextBox ID="End" runat="server" type="date" CssClass="select"></asp:TextBox>

            <div>Semester Code</div>
            <asp:TextBox id="Code" runat="server" placeholder="Enter Semester Code" CssClass="select"></asp:TextBox>

            <div style="text-align: center;">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddSemester" />
                <br/>
                <asp:Button ID="btnBack" runat="server" Text="Back" Onclick="back" />
            </div>

            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
