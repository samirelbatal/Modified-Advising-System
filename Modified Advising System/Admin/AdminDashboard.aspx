<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Modified_Advising_System.AdminDashboard" %>

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
            max-width: 600px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }

        h1 {
            text-align: center;
            color: #333;
        }

        #form1 div {
            text-align: center;
            margin-bottom: 20px;
        }
        #dashboardLabel {
         font-size: 45px;
         font-weight: bold;
         margin-bottom: 20px;
}

        .dashboard-button {
            padding: 15px 30px;
            font-size: 18px;
            margin-bottom: 10px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease, transform 0.2s ease;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .dashboard-button:hover {
            background-color: #45a049;
            transform: scale(1.05);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="dashboardLabel" runat="server" Text="Admin DashBoard 2.0"></asp:Label>
             <br/>
             <br/>
            <asp:Button ID="Deletecourse" runat="server" OnClick="deletecourse" Text="Delete a course" CssClass="dashboard-button" />
           <br />
            <br />
              <asp:Button ID="Deleteslot" runat="server" OnClick="deleteslot" Text="Delete a slot of a certain course" CssClass="dashboard-button"/>
            <br />
            <br />
            <asp:Button ID="MakeupExam" runat="server" OnClick="addmakeup" Text="Add Make Up exam" CssClass="dashboard-button"/>
             <br />
             <br />
            <asp:Button ID="Studentpayment" runat="server" OnClick="viewpayments" Text="View all payments with their corresponding students" CssClass="dashboard-button"/>
             <br />
             <br />
            <asp:Button ID="installment" runat="server" OnClick="issueinstallments" Text="Issue installments for a payment" CssClass="dashboard-button"/>
             <br />   
            <br />
            <asp:Button ID="updatestudentstat" runat="server" OnClick="updatestatus" Text="Update a Student status based on his financial status" CssClass="dashboard-button"/>
            <br />
            <br />
            <asp:Button ID="activestudents" runat="server" onclick="activestudent" Text="Fetch all details of active students" CssClass="dashboard-button"/>
            <br />
            <br />
            <asp:Button ID="gradplan" runat="server" onclick="gradplans" Text="View Graduation Plan along with their intiated advisors" CssClass="dashboard-button"/>
            <br />
           <br />
           <asp:Button ID="transcript" runat="server" onclick="studentstranscript" Text="View all students transcript details" CssClass="dashboard-button"/>


        </div>
    </form>
</body>
</html>
