<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminViewInstructorWithAssignedCourses.aspx.cs" Inherits="Modified_Advising_System.AdminViewInstructorWithAssignedCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        margin: 0;
        padding: 0;
        background-color: #f4f4f4;
    }

    .container {
        max-width: 1000px;
        margin: 20px auto;
        position: relative;
    }

    .back-button {
        background-color: #3498db; /* Blue color */
        color: #fff;
        padding: 15px 20px;
        border: none;
        border-radius: 5px;
        font-size: larger;
        cursor: pointer;
        position: absolute;
        top: 10px;
        left: 10px;
        transition: background-color 0.3s ease;

    }

    .back-button:hover {
        background-color: #2980b9;
    }

    .flexbox {
        display: flex;
        flex-direction: row;
        grid-template-columns: repeat(4, 1fr);
        background-color: #2c3e50;
        color: #ecf0f1;
        justify-content: space-between;
        padding: 15px;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    }
    .flexbox2{
        display: flex;
        flex-direction: row;
        grid-template-columns: repeat(4, 1fr);
        background-color: white;
        color: black;
        padding: 15px;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    }

    .label {
        margin-right: 20px;
        padding: 10px;
        border: 1px solid #34495e;
        border-radius: 5px;
        font-size: large;
        display: flex;
        align-items: center;
        background-color: #34495e; /* Label background color */
        color: #fff; /* Label text color */
    }

    .content1 {
        font-size: large;
        padding: 10px;
        width:200px;

    }
    .content2 {
        font-size: large;
        padding: 10px;
        width:20px;
        margin-left: 110px;
    }
        .content3 {
    font-size: large;
        padding: 10px;
            margin-left: 180px;
            width:200px;
;

}
        
        .content4 {
    font-size: large;
        padding: 10px;
                    margin-left: 110px;


}

    h1 {
        text-align: center;
        color: #2c3e50;
        margin-top: 20px;
    }

    .advisor-panel {
        margin-top: 20px;
        padding: 15px;
        border: 1px solid #34495e;
        border-radius: 5px;
    }
     
</style>
</head>
<body>
    <form id="form1" runat="server">
         <asp:Button CssClass="back-button" ID="btnBack" runat="server" Text="Back To Dashboard" Onclick="back" />

            <div class="container">
    <h1>Instructor and Course Information</h1>
    <div class="flexbox">
        <div class="label">Instructor Name</div>
        <div class="label">Instructor ID</div>
        <div class="label">Course Name</div>
        <div class="label">Course ID</div>
    </div>
        <div style ="display:grid;" id="flow" runat="server">
    
        </div>

    <!-- Dynamic advisor panels will be added here -->

</div>
    </form>
</body>
</html>
