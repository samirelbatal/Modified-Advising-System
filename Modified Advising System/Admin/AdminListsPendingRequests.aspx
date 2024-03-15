<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminListsPendingRequests.aspx.cs" Inherits="Modified_Advising_System.AdminListsPendingRequests" %>


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
        max-width: 2000px; /* Adjust the max-width to make the table wider */
        margin: 20px auto;
        position: relative;
        margin-top:40px;
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
        grid-template-columns: repeat(8, 1fr);
        background-color: #2c3e50;
        color: #ecf0f1;
        justify-content: space-between;
        padding: 15px;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    }

    .flexbox2 {
        display: flex;
        flex-direction: row;
        grid-template-columns: repeat(8, 1fr);
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
        padding: 10px;
        font-size: large;
        width:15px;
        /* Add additional styles for content if needed */
    }
    .content2 {
    padding: 10px;
    margin-left: 160px;
    font-size: large;
    width:90px;
    /* Add additional styles for content if needed */
}
        .content3 {
    padding: 10px;
    margin-left: 70px;
    font-size: large;
    width:250px;

    /* Add additional styles for content if needed */
}
        .content4 {
    padding: 10px;
    margin-left: 100px;
    font-size: large;
    width:40px;
    /* Add additional styles for content if needed */
}
        .content5 {
    padding: 10px;
    margin-left: 230px;
    font-size: large;
        width:20px;

    /* Add additional styles for content if needed */
}
        .content6 {
    padding: 10px;
    margin-left: 250px;
    font-size: large;
    width:20px;
    /* Add additional styles for content if needed */
}
        .content7 {
    padding: 10px;
    margin-left: 230px;
    font-size: large;    
    width:20px;

    /* Add additional styles for content if needed */
}
        .content8 {
    padding: 10px;
    margin-left: 250px;
    font-size: large;
    width:20px;

    /* Add additional styles for content if needed */
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
           <div><asp:Button  CssClass="back-button" ID="btnBack" runat="server" Text="Back To Dashboard" Onclick="back"  /></div>
        <br/>

        <div class="container">
        <h1>Requests Information</h1>
        <div class="flexbox">
            <div class="label"> RID</div>
            <div class="label">type</div>
            <div class="label">comment</div>
            <div class="label">status</div>
            <div class="label">credit hours</div>
            <div class="label">course ID</div>
            <div class="label">student ID</div>
            <div class="label">advisor ID </div>
        </div>
        <div style ="display:grid;" id="flow" runat="server">
            
        </div>

        <div id="Div1" runat="server"></div>
    </div>
    </form>
</body>
</html>