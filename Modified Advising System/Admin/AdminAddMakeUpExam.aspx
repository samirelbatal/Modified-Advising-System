<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAddMakeUpExam.aspx.cs" Inherits="Modified_Advising_System.AddMakeUpExam" %>

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

        form {
            max-width: 400px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }

        #form1 div {
            text-align: center;
            margin-bottom: 20px;
        }

        #form1 input[type="text"],
        #form1 input[type="date"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        #form1 .select {  
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        #form1 .add-exam-button {
            padding: 12px 20px;
            font-size: 16px;
            background-color: cadetblue; 
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        #form1 .add-exam-button:hover {
            background-color: dimgray;
        }

        #form1 .dashboard-button {
            padding: 12px 20px;
            font-size: 16px;
            background-color: #3498db; /* Blue color */
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        #form1 .dashboard-button:hover {
            background-color: #2980b9;
        }

        #form1 .message {
            font-size: 20px;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
       Choose Exam Type:<br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="type" DataValueField="type" CssClass="select"></asp:DropDownList>

            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Advising_Management_System %>' SelectCommand="SELECT DISTINCT [type] FROM MakeUP_Exam"></asp:SqlDataSource>
            <br/>
            <br/>
           Choose Exam Date: <br/>
            <asp:TextBox ID="exam_date" runat="server" type="date" CssClass="textbox"></asp:TextBox>
            <br/>
            <br/>
            Enter Course ID: <br/>
            <asp:TextBox ID="course" runat="server" CssClass="textbox"></asp:TextBox>
            <br/>
            <br/>
            <asp:Button ID="Register" runat="server" OnClick="funcaddexam" Text="Add Make Up Exam" CssClass="add-exam-button"/>

            <br/>
            <br/>
            <asp:Button ID="Button1" runat="server" OnClick="back" Text="Go Back To DashBoard" CssClass="dashboard-button" />
            <br />
              <asp:Label ID="lblMessage" runat="server" CssClass="message" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
