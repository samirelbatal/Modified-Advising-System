<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminViewSemestersWithOfferedCourses.aspx.cs" Inherits="Modified_Advising_System.AdminViewSemestersWithOfferedCourses" %>

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
        grid-template-columns: repeat(3, 1fr);
        background-color: #2c3e50;
        color: #ecf0f1;
        justify-content: space-between;
        padding: 15px;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    }
    .flexbox2{
        display: flex;
        flex-direction: row;
        grid-template-columns: repeat(3, 1fr);
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
        background-color: #34495e; 
        color: #fff; 
    }

    .content1 {
        width:250px;
        padding: 10px;
        font-size: large;
    }
    .content2 {
     margin-left: 180px;

    padding: 10px;
    font-size: large;
}
    .content3 {
    margin-left: 370px;

    padding: 10px;
    font-size: large;
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
    <h1>Course Information</h1>
    <div class="flexbox">
        <div class="label">Course name</div>
        <div class="label">Couse ID</div>
        <div class="label">Semester Code</div>
    </div>
        <div style ="display:grid;" id="flow" runat="server">
    
        </div>


</div>
    </form>
</body>
</html>
