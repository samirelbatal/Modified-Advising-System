<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAddingCourse.aspx.cs" Inherits="Modified_Advising_System.AdminAddingCourse" %>

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
            font-size:30px
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
            margin-top:15px
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
        <h2>Adding Course</h2>
        <div>
            <div>Choose a major</div>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="major" DataValueField="major" CssClass="select"></asp:DropDownList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Advising_Management_System %>' SelectCommand="SELECT DISTINCT [major] FROM Student"></asp:SqlDataSource>

            <div> Choose semester</div>
            <asp:TextBox runat="server" ID="semester" CssClass="select"></asp:TextBox>

            <div>Enter Course credit hours</div>
            <asp:TextBox runat="server" ID="hours" CssClass="select"></asp:TextBox>

            <div>Enter course name </div>
            <asp:TextBox runat="server" ID="name" CssClass="select"></asp:TextBox>

            <div>Enter offered bit</div>
            <asp:TextBox runat="server" ID="bit" CssClass="select"></asp:TextBox>

            <div style="text-align: center;">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddCourse" />
                <br />
                <asp:Button ID="btnBack" runat="server" Text="Back" Onclick="back" />
            </div>

            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
